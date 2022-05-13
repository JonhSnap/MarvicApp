﻿using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Issue_Request.Issue_Request;
using MarvicSolution.Services.Sprint_Request.Requests;
using MarvicSolution.Services.Sprint_Request.ViewModels;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Sprint_Request.Services
{
    public class Sprint_Service : ISprint_Service
    {
        private readonly MarvicDbContext _context;
        private readonly IIssue_Service _issue_Service;

        public Sprint_Service(MarvicDbContext context, IIssue_Service issue_Service)
        {
            _context = context;
            _issue_Service = issue_Service;
        }

        public Guid AddIssuesToSprint(AddIssue_Request rq)
        {
            try
            {
                foreach (var i_id in rq.ListIdIssue)
                {
                    var issue = _context.Issues.SingleOrDefault(i => i.Id.Equals(i_id));
                    if (issue == null)
                        throw new MarvicException($"Cannot find issue = {i_id}");
                    issue.Id_Sprint = rq.IdSprint;
                    _context.SaveChanges();
                }
                return rq.IdSprint;
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        public async Task<bool> AddSprint(Sprint sprint)
        {
            try
            {
                _context.Sprints.Add(sprint);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // log here...
                return false;
            }
        }

        public async Task<bool> CompleteSprint(Complete_Sprint_Request model)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                //get id stage done in project have a complete_Sprint_Request.OldSprintId
                var stageDoneId = await _context.Stages
                    .Where(stg => stg.Id_Project == model.CurrentProjectId && 
                    stg.isDone == EnumStatus.True &&
                    stg.isDeleted == EnumStatus.False)
                    .Select(stage => stage.Id)
                    .FirstOrDefaultAsync();

                //get list issue undone
                var listIssueUnDone = await _context.Issues
                    .Where(a => a.Id_Sprint == model.CurrentSprintId &&
                    a.IsDeleted == EnumStatus.False &&
                    a.Id_Stage!= stageDoneId)
                    .ToListAsync();

                foreach (var item in listIssueUnDone)
                {
                    item.Id_Sprint = model.NewSprintId;
                }
                //change issue to new sprint
                _context.Issues.UpdateRange(listIssueUnDone);

                //remove current sprint
                var currentSprint = await _context.Sprints.FindAsync(model.CurrentSprintId);
                currentSprint.Is_Archieved = EnumStatus.True;
                _context.Sprints.Update(currentSprint);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // log here...
                return false;
            }
        }

        public async Task<bool> DeleteSprint(Sprint sprint)
        {
            try
            {
                _context.Sprints.Update(sprint);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // log here...
                return false;
            }
        }

        public async Task<Sprint> GetSprintById(Guid id)
        {
            try
            {
                var sprint = await _context.Sprints.FirstOrDefaultAsync(sprt => sprt.Id == id && sprt.Is_Archieved == EnumStatus.False);
                return sprint;
            }
            catch (Exception ex)
            {
                // log here...
                throw;
            }
        }

        public async Task<IList<SprintVM>> GetSprintsById_Project(Guid id_Project)
        {
            try
            {
                var sprints = await _context.Sprints
                    .Where(spr => spr.Id_Project == id_Project && spr.Is_Archieved == EnumStatus.False)
                    .Select(spr => new SprintVM(spr.Id, spr.Id_Project, spr.SprintName, spr.Id_Creator, spr.Update_Date, 
                    spr.Create_Date, spr.Start_Date, spr.End_Date, spr.Is_Archieved, spr.Is_Started))
                    .ToListAsync();
                return sprints;
            }
            catch (Exception ex)
            {
                // log here...
                throw;
            }
        }

        public bool RemoveIssuesFromSprint(RemoveIssue_Request rq)
        {
            try
            {
                foreach (var i_id in rq.ListIdIssue)
                {
                    var issue = _context.Issues.SingleOrDefault(i => i.Id.Equals(i_id));
                    if (issue == null)
                        throw new MarvicException($"Cannot find issue = {i_id}");
                    issue.Id_Sprint = Guid.Empty;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        public async Task<bool> UpdateSprint(Sprint sprint)
        {
            try
            {
                _context.Sprints.Update(sprint);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ///ghi log
                return false;
                throw;
            }
        }

    }
}

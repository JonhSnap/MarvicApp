select p.Id as IdProject, i.Id as IdIssue, mem.Id_User, i.Id_Assignee, i.Summary
from Project p, Member mem, Issue i
where p.Id = mem.Id_Project 
		and p.Id = i.Id_Project 
		and mem.Id_User = i.Id_Assignee



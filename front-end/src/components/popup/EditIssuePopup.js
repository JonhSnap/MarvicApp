/* eslint-disable react/jsx-no-comment-textnodes */
import React, { useEffect, useState, memo, useMemo, useRef } from 'react'
import './EditIssuePopup.scss'
import axios from 'axios'
import { NIL } from 'uuid'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBolt, faArrowDownWideShort } from '@fortawesome/free-solid-svg-icons'
import MemberPopup from '../board/MemberComponent'
import CKEditorComponent from '../CKEditorComponent'
import ModalBase from '../modal/ModalBase'
import { fetchIssue, updateIssues } from '../../reducers/listIssueReducer'
import { useListIssueContext } from '../../contexts/listIssueContext'
import createToast from '../../util/createToast'
import OptionsEditIssue from '../option/OptionsEditIssue'
import IssueCanAddSelectbox from '../selectbox/IssueCanAddSelectbox'
import { BASE_URL, issueTypes } from '../../util/constants'
import AttachmentForm from '../form/AttachmentForm'
import { useStageContext } from '../../contexts/stageContext'
import { useSprintContext } from '../../contexts/sprintContext'
import Comments from '../comments/Comments'

function EditIssuePopup({ members, project, issue, setShow }) {
  const [{ issueEpics }, dispatch] = useListIssueContext();
  const { state: { sprints } } = useSprintContext();
  const [{ stages }] = useStageContext();
  const [showEpic, setShowEpic] = useState(false);
  const [valuesStore, setValuesStore] = useState({});
  const [showCKEditorCMT, setShowCKEditorCMT] = useState(false)
  const [showAddchild, setShowAddchild] = useState(false);
  const [showAttachment, setShowAttachment] = useState(false);
  const [childIssues, setChildIssues] = useState([]);

  const [values, setValues] = useState({
    summary: issue?.summary,
    description: issue?.description || ''
  });

  // create issue update
  const issueUpdate = useMemo(() => {
    const issueCopy = { ...issue, ...values };
    return issueCopy;
  }, [values.description, values.summary])
  // stage
  const stage = useMemo(() => {
    const result = stages.find((item) => item.id === issue.id_Stage);
    if (!result) return null;
    return result;
  }, [stages]);
  // current sprint
  const currentSprint = useMemo(() => {
    return sprints.find(item => item.is_Started);
  }, [sprints])
  // handle close edit
  const handleCloseEditByButton = async () => {
    if (issueUpdate.summary === valuesStore.summary && issueUpdate.description === valuesStore.description) {
      setShow(false);
      return;
    }
    issueUpdate.attachment_Path = null;
    await updateIssues(issueUpdate, dispatch);
    await fetchIssue(project.id, dispatch);
    createToast('success', 'Update issue successfully!');
    setShow(false);
  }
  // handle close edit by click outside
  const handleCloseEditByClickOutside = async (e) => {
    if (!e.target.closest('.content')) {
      if (issueUpdate.summary === valuesStore.summary && issueUpdate.description === valuesStore.description) {
        setShow(false);
        return;
      }
      issueUpdate.attachment_Path = null;
      await updateIssues(issueUpdate, dispatch);
      await fetchIssue(project.id, dispatch);
      createToast('success', 'Update issue successfully!');
      setShow(false);
    }
  }
  // current epic
  const currentEpic = issueEpics.find(item => item.id === issue.id_Parent_Issue);
  // handle values change
  const handleValuesChange = (e) => {
    if (e.target.name === 'summary') {
      setValues({
        ...values,
        [e.target.name]: e.target.value
      })
    } else if (e.target.name === 'description') {
      setValues({
        ...values,
        [e.target.name]: e.target.value
      })
    }
  }
  // useEffect
  useEffect(() => {
    setValuesStore({
      summary: values.summary,
      description: values.description
    })
  }, [issue])
  // get child issue
  useEffect(() => {
    axios.get(`https://localhost:5001/api/Issue/GetIssueByIdParent?IdProject=${project.id}&IdParent=${issue.id}`)
      .then(resp => {
        if (resp.status === 200) {
          return resp.data;
        }
      })
      .then(data => {
        setChildIssues(data)
      })
      .catch(err => console.log(err))
  }, [project, issue])
  // handle toggle epic
  const handleToggleEpic = (e) => {
    if (e.target.matches('.epic-dropdown')) {
      setShowEpic(prev => !prev);
    } else {
      return;
    }
  }
  // handle choose epic
  const handleChooseEpic = (epic) => {
    const issueUpdate = { ...issue }
    issueUpdate.id_Parent_Issue = epic.id;
    updateIssues(issueUpdate, dispatch);
    createToast('success', `Update epic successfully!`);
    setTimeout(() => {
      fetchIssue(project.id, dispatch);
    }, 500);
  }
  // handle remove epic
  const handleRemoveEpic = () => {
    const issueUpdate = { ...issue };
    issueUpdate.id_Parent_Issue = null;
    updateIssues(issueUpdate, dispatch);
    createToast('success', 'Remove epic successfully!');
    setTimeout(() => {
      fetchIssue(project.id, dispatch);
    }, 500);
  }

  const showCKEditorCMTClick = () => {
    setShowCKEditorCMT(true)
  }
  const hiddenCKEditorCMTClick = () => {
    setShowCKEditorCMT(false)
  }
  return (
    <ModalBase
      containerclassName='fixed inset-0 z-10 flex items-center justify-center'
      bodyClassname='relative content-modal'
      onClose={handleCloseEditByClickOutside}>
      <label htmlFor="close-option">
        <div
          className='have-y-scroll h-[80vh] overflow-auto bg-white  mb-10 overflow-x-hidden
        flex flex-col flex-[2]  mx-4 relative p-5 rounded-md'>
          <IssueCanAddSelectbox
            project={project}
            issue={issue}
            showAddchild={showAddchild}
            setShowAddchild={setShowAddchild}
            childIssues={childIssues}
          />
          <AttachmentForm
            issue={issue}
            setShowAttachment={setShowAttachment}
            showAttachment={showAttachment}
          />
          <div className='flex justify-between items-start'>
            {
              issue.id_IssueType !== 1 &&
              <div className='flex items-center'>
                <div
                  onClick={handleToggleEpic}
                  className='epic-dropdown relative z-10 flex items-center gap-x-2 p-2 rounded
                            cursor-pointer bg-[#8777D9] bg-opacity-20 hover:bg-opacity-50'>
                  <FontAwesomeIcon size='1x' className='pointer-events-none mx-1 p-[0.2rem] text-white text-[10px] inline-block bg-[#904ee2]' icon={faBolt} />
                  <span className='pointer-events-none'>
                    {currentEpic ?
                      currentEpic.summary :
                      'Add epic'
                    }
                  </span>
                  <span className='pointer-events-none inline-block h-5 w-5'>
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
                      <path strokeLinecap="round" strokeLinejoin="round" d="M19 9l-7 7-7-7" />
                    </svg>
                  </span>
                  {
                    showEpic &&
                    <div
                      className="have-y-scroll absolute w-fit max-h-[150px] overflow-auto p-2 rounded bg-white shadow-md shadow-[#8777D9] left-0 top-[calc(100%+10px)]">
                      {
                        issueEpics.length > 0 &&
                        issueEpics.filter(epicItem => epicItem.id !== issue.id_Parent_Issue).map(item => (
                          <div
                            onClick={() => handleChooseEpic(item)}
                            className='w-[150px] mb-2 p-3 bg-white rounded shadow-md font-semibold
                                            hover:bg-[#8777D9] hover:text-white'
                            key={item.id}>{item.summary}</div>
                        ))
                      }
                      {
                        issue.id_Parent_Issue && issue.id_Parent_Issue !== '00000000-0000-0000-0000-000000000000' &&
                        <div
                          onClick={handleRemoveEpic}
                          className='flex items-center gap-x-2 w-[150px] mb-2 p-3 bg-red-500 text-white rounded shadow-md font-semibold'
                        >
                          <span className='inline-block w-5 h-5'>
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
                              <path strokeLinecap="round" strokeLinejoin="round" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                            </svg>
                          </span>
                          <span>Remove epic</span>
                        </div>
                      }
                    </div>
                  }
                </div>
              </div>
            }
            <div className='flex items-center gap-x-2 ml-auto'>
              <OptionsEditIssue
                setShowAttachment={setShowAttachment}
                setShowAddchild={setShowAddchild}
              />
              <div
                onClick={handleCloseEditByButton}
                className='w-6 h-6 flex justify-center items-center text-gray-500 rounded-full
                        hover:bg-primary hover:bg-opacity-30 cursor-pointer transition-all'
              >
                <span className='inline-flex items-center justify-center w-4 h-4'>
                  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                    <path fillRule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clipRule="evenodd" />
                  </svg>
                </span>
              </div>
            </div>
          </div>
          <div className='text-2xl font-bold my-4'>
            <input
              spellCheck={false}
              value={values.summary}
              onChange={handleValuesChange}
              name='summary'
              className='w-full outline-none border-2 border-transparent p-2 rounded-md focus:border-primary'
              type="text" />
          </div>
          <div className='flex items-center gap-x-2 mb-4'>
            {/* <Stages project={project} issue={issue} stage={stage} /> */}
            <Stage project={project} issue={issue} stages={stages} stage={stage} />
            {
              issue?.isFlagged === 1 &&
              <div className='flex items-center w-fit'>
                <span
                  className='text-[#EF0000] w-5 h-5'
                >
                  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                    <path fillRule="evenodd" d="M3 6a3 3 0 013-3h10a1 1 0 01.8 1.6L14.25 8l2.55 3.4A1 1 0 0116 13H6a1 1 0 00-1 1v3a1 1 0 11-2 0V6z" clipRule="evenodd" />
                  </svg>
                </span>
                Flagged
              </div>
            }
          </div>
          <div className='font-bold m-1'>
            Description
          </div>
          <div>
            <TextBox
              spellCheck={false}
              value={values.description}
              onChange={handleValuesChange}
              placeholder='Enter description...'
              name='description'
            />
          </div>
          <Attachment issue={issue} />
          <ChildIssue
            project={project}
            issues={childIssues}
          />

          <div className='detail'>
            <div className='item w-full h-13 p-1 bg-white px-4 mt-[-1px] border-solid border border-[#ccc] border-b-0 flex justify-between items-center'>
              <div className='flex justify-between w-full h-8 items-center my-2'>
                <p className='font-bold m-1'>
                  Detail
                </p>
              </div>
            </div>
            <div className='item w-full h-13 p-1 bg-white px-4 mt-[-1px] border-solid border-[1px] border-[#ccc] flex justify-between items-center flex-wrap'>
              <div className='w-[40%] h-13 my-4'>
                Assignee
              </div>
              <div className='w-[60%]'>
                <Assignee members={members} project={project} issue={issue} />
              </div>
              <div className='w-[40%] h-13 my-4'>
                Labels
              </div>
              <div className='w-[60%]'>
                None
              </div>
              <div className='w-[40%] h-13 my-4'>
                Sprint
              </div>
              <div className='w-[60%]'>
                {currentSprint?.sprintName}
              </div>
              <div className='w-[40%] h-13 my-4'>
                Story point estimate
              </div>
              <div className='w-[60%]'>
                {issue?.story_Point_Estimate}
              </div>
              <div className='w-[40%] h-13 my-4'>
                Reporter
              </div>
              <div className='w-[60%]'>
                <Reporter members={members} project={project} issue={issue} />
              </div>
            </div>
          </div>
          <div className='flex justify-between my-4 text-[#a1a1a1]'>
            <span>Created 16 hours ago</span>
            <span>Updated 7 hours ago</span>
          </div>
          <div className="flex items-center my-5">
            <Comments
              commentURL="https://localhost:5001/hubs/marvic"
              IdIssueComment={issue.id}
            />
          </div>
        </div>
      </label>
    </ModalBase>
  )
}

export default memo(EditIssuePopup)

// child issue
function ChildIssue({ issues, project }) {
  const [, dispatchIssue] = useListIssueContext();

  // handle remove child
  const handleRemoveChild = async (child) => {
    child.id_Parent_Issue = NIL;
    await updateIssues(child, dispatchIssue);
    fetchIssue(project.id, dispatchIssue);
    createToast('success', 'Remove child successfully')
  }

  return (
    <div className='child-issue'>
      <p className='title'>Child issue</p>
      <div className='list-issue have-y-scroll'>
        {
          issues.length === 0 &&
          <p>No child issue</p>
        }
        {
          issues.length > 0 &&
          issues.map(issue => (
            <div key={issue.id} className="issue-item">
              <div className='img'>
                <img src={issueTypes.find(item => item.value === issue.id_IssueType).thumbnail} alt="" />
              </div>
              <span className='summary'>{issue.summary}</span>
              <span onClick={() => handleRemoveChild(issue)} title='Remove' className='delete-child'>
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
                  <path strokeLinecap="round" strokeLinejoin="round" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                </svg>
              </span>
            </div>
          ))
        }
      </div>
    </div>
  )
}
// attachment
function Attachment({ issue }) {
  const downloadRef = useRef();
  // handle download
  const handleDownload = () => {
    const lastBacklashIndex = issue.attachment_Path.lastIndexOf('/');
    const fileName = issue.attachment_Path.slice(lastBacklashIndex + 1)
    const path = `${BASE_URL}/api/Issue/download?fileName=${fileName}`;
    if (fileName) {
      downloadRef.current.href = path;
      downloadRef.current.click();
    }
  }

  return (
    <div className='attach'>
      <p className='title'>Attachment</p>
      {
        !issue.attachment_Path ?
          <p>No attachment</p> :
          <div className='download'>
            <div className='image'>
              <img src={issue.attachment_Path} alt="" />
            </div>
            <a ref={downloadRef} hidden href='/'>download</a>
            <span onClick={handleDownload} className='btn-download'>
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
                <path strokeLinecap="round" strokeLinejoin="round" d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-4l-4 4m0 0l-4-4m4 4V4" />
              </svg>
            </span>
          </div>
      }
    </div>
  )
}
// text area
function TextBox({ value, onChange, ...props }) {
  const nodeRef = useRef();
  const [height, setHeight] = useState('auto');
  const [text, setText] = useState(value)
  // handle change
  const handleChange = (e) => {
    setText(e.target.value);
    setHeight('auto');
    onChange(e);
  }
  useEffect(() => {
    if (text) {
      setHeight(nodeRef.current.scrollHeight);
    }
  }, [text])
  return (
    <textarea
      {...props}
      ref={nodeRef}
      style={{ height: height }}
      value={text}
      onChange={handleChange}
      className='overflow-hidden resize-none w-full outline-none border-2 border-transparent p-2
    rounded-md focus:border-primary'
    ></textarea>
  )
}
// Stage
function Stage({ project, issue, stages, stage }) {
  const [show, setShow] = useState(false);
  const [, dispatchIssue] = useListIssueContext();
  // toggle
  const toggle = (e) => {
    if (e.target.matches('.btn-toggle')) {
      setShow(prev => !prev)
    }
  }
  // handle change stage
  const handleChangeStage = async (stage) => {
    if (stage) {
      issue.id_Stage = stage.id;
      await updateIssues(issue, dispatchIssue);
      fetchIssue(project.id, dispatchIssue);
      createToast('success', 'Update stage successfully');
    }
  }

  return (
    <div onClick={toggle} className='btn-toggle relative flex gap-x-2 items-center justify-center px-4 py-2
    rounded bg-gray-main cursor-pointer hover:bg-gray-200 transition-all'>
      <span className='inline-block uppercase font-semibold pointer-events-none'>{stage.stage_Name}</span>
      <span className='inline-block w-5 h-5 text-inherit pointer-events-none'>
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
          <path fillRule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clipRule="evenodd" />
        </svg>
      </span>
      {
        show &&
        <div className="absolute w-[110%] z-10 top-[105%] left-0 bg-gray-main rounded shadow-md">
          {
            stages.length > 0 &&
            stages.map(item => {
              return (
                item.id !== stage.id
                  ? <p key={item.id} onClick={() => handleChangeStage(item)} className='p-2 uppercase cursor-pointer hover:bg-gray-200'>{item.stage_Name}</p>
                  : null
              )

            })
          }
        </div>
      }
    </div>
  )
}
// Assign
function Assignee({ members, project, issue }) {
  const [, dispathIssue] = useListIssueContext();
  const [show, setShow] = useState(false);

  // current assignee
  const currentAssignee = useMemo(() => {
    return members.find(item => item.id === issue.id_Assignee)
  }, [members, issue])
  // toggle
  const toggle = (e) => {
    if (e.target.matches('.toggle')) {
      setShow(prev => !prev)
    }
  }
  // handle select member
  const handleSelectMember = async (member) => {
    if (member === null) {
      issue.id_Assignee = NIL;
    } else {
      issue.id_Assignee = member.id;
    }
    await updateIssues(issue, dispathIssue);
    fetchIssue(project.id, dispathIssue);
    createToast('success', 'Change assignee sucessfully');
  }

  return (
    <div onClick={toggle} className='toggle relative z-10 w-6 h-6 bg-white rounded-full cursor-pointer'>
      {
        currentAssignee ?
          <span
            className='pointer-events-none inline-flex items-center justify-center w-full h-full rounded-full bg-orange-500 text-white'>{currentAssignee.userName.slice(0, 1)}</span> :
          <span className="inline-block w-full h-full text-[#ccc] hover:text-gray-500 pointer-events-none">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 20 20"
              fill="currentColor"
            >
              <path
                fillRule="evenodd"
                d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.986 5.986 0 0010 16a5.986 5.986 0 004.546-2.084A5 5 0 0010 11z"
                clipRule="evenodd"
              />
            </svg>
          </span>
      }
      {
        show &&
        <div
          style={{ transform: 'translateX(-25%)' }}
          className='absolute top-[105%] left-0 shadow-md bg-white max-h-[150px] overflow-auto have-y-scroll'>
          <div onClick={() => handleSelectMember(null)} className='p-2 flex items-center'>Unassignee</div>
          {
            members.length > 0 &&
            members.map(item => (
              <div
                onClick={() => handleSelectMember(item)}
                key={item.id}
                className={`p-2 flex items-center hover:bg-gray-main ${issue.id_Assignee === item.id ? 'bg-orange-500 text-white pointer-events-none' : ''}`}
              >{item.userName}</div>
            ))
          }
        </div>
      }
    </div>
  )
}
// Reporter
function Reporter({ members, project, issue }) {
  const [, dispathIssue] = useListIssueContext();
  const [show, setShow] = useState(false);

  // current assignee
  const currentAssignee = useMemo(() => {
    return members.find(item => item.id === issue.id_Reporter)
  }, [members, issue])
  // toggle
  const toggle = (e) => {
    if (e.target.matches('.toggle')) {
      setShow(prev => !prev)
    }
  }
  // handle select member
  const handleSelectMember = async (member) => {
    issue.id_Assignee = member.id;
    await updateIssues(issue, dispathIssue);
    fetchIssue(project.id, dispathIssue);
    createToast('success', 'Change reporter sucessfully');
  }

  return (
    <div onClick={toggle} className='toggle relative z-10 w-6 h-6 bg-white rounded-full cursor-pointer'>
      {
        currentAssignee ?
          <span
            className='pointer-events-none inline-flex items-center justify-center w-full h-full rounded-full bg-orange-500 text-white'>{currentAssignee.userName.slice(0, 1)}</span> :
          <span className="inline-block w-full h-full text-[#ccc] hover:text-gray-500 pointer-events-none">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 20 20"
              fill="currentColor"
            >
              <path
                fillRule="evenodd"
                d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.986 5.986 0 0010 16a5.986 5.986 0 004.546-2.084A5 5 0 0010 11z"
                clipRule="evenodd"
              />
            </svg>
          </span>
      }
      {
        show &&
        <div
          style={{ transform: 'translateX(-25%)' }}
          className='absolute top-[105%] left-0 shadow-md bg-white max-h-[150px] overflow-auto have-y-scroll'>
          {
            members.length > 0 &&
            members.map(item => (
              <div
                onClick={() => handleSelectMember(item)}
                key={item.id}
                className={`p-2 flex items-center hover:bg-gray-main ${issue.id_Reporter === item.id ? 'bg-orange-500 text-white pointer-events-none' : ''}`}
              >{item.userName}</div>
            ))
          }
        </div>
      }
    </div>
  )
}
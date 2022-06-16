/* eslint-disable react/jsx-no-comment-textnodes */
import React, { useEffect, useState, memo, useMemo, useRef } from "react";
import "./EditIssuePopup.scss";
import axios from "axios";
import { NIL } from "uuid";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faBolt,
} from "@fortawesome/free-solid-svg-icons";
import ModalBase from "../modal/ModalBase";
import { fetchIssue, updateIssues } from "../../reducers/listIssueReducer";
import { useListIssueContext } from "../../contexts/listIssueContext";
import createToast from "../../util/createToast";
import OptionsEditIssue from "../option/OptionsEditIssue";
import IssueCanAddSelectbox from "../selectbox/IssueCanAddSelectbox";
import { BASE_URL, issueTypes } from "../../util/constants";
import AttachmentForm from "../form/AttachmentForm";
import { useStageContext } from "../../contexts/stageContext";
import { useSprintContext } from "../../contexts/sprintContext";
import Comments from "../comments/Comments";
import { fetchBoard } from "../../reducers/boardReducer";
import { useBoardContext } from "../../contexts/boardContext";
import { ModalProvider, useModalContext } from "../../contexts/modalContext";
import LinkIssueSelectbox from "../selectbox/LinkIssueSelectbox";
import { useLabelContext } from "../../contexts/labelContext";


function EditArchiveIssuePopup({ members, project, issue, setShow }) {
  const [{ issueEpics }, dispatch] = useListIssueContext();
  const [, dispatchBoard] = useBoardContext();
  const {
    state: { sprints },
  } = useSprintContext();
  const [{ stages }] = useStageContext();
  const [showEpic, setShowEpic] = useState(false);
  const [valuesStore, setValuesStore] = useState({});
  const [showCKEditorCMT, setShowCKEditorCMT] = useState(false);
  const [showAddchild, setShowAddchild] = useState(false);
  const [showAttachment, setShowAttachment] = useState(false);
  const [showLinkIssue, setShowLinkIssue] = useState(false);
  const [childIssues, setChildIssues] = useState([]);

  const [selectedDateStart, setSelectedDateStart] = useState(() => {
    const date = new Date(issue?.dateStarted);
    const dd = String(date.getDate()).padStart(2, "0");
    const mm = String(date.getMonth() + 1).padStart(2, "0"); //January is 0!
    const yyyy = date.getFullYear();
    return yyyy + "-" + mm + "-" + dd;
  });
  const [selectedDateEnd, setSelectedDateEnd] = useState(() => {
    const date = new Date(issue?.dateEnd);
    const dd = String(date.getDate()).padStart(2, "0");
    const mm = String(date.getMonth() + 1).padStart(2, "0"); //January is 0!
    const yyyy = date.getFullYear();
    return yyyy + "-" + mm + "-" + dd;
  });

  const [values, setValues] = useState({
    summary: issue?.summary,
    description: issue?.description || "",
    dateStarted: selectedDateStart,
    dateEnd: selectedDateEnd,
  });

  // create issue update
  const issueUpdate = useMemo(() => {
    const issueCopy = { ...issue, ...values };
    return issueCopy;
  }, [values]);
  // stage
  const stage = stages.find((item) => item.id === issue.id_Stage);
  // current sprint
  const currentSprint = useMemo(() => {
    return sprints.find((item) => item.is_Started);
  }, [sprints]);
  // handle close edit
  const handleCloseEditByButton = async () => {
    if (
      issueUpdate.summary === valuesStore.summary &&
      issueUpdate.description === valuesStore.description &&
      issueUpdate.dateStarted === valuesStore.dateStarted &&
      issueUpdate.dateEnd === valuesStore.dateEnd
    ) {
      setShow(false);
      return;
    }
    console.log('issue update', issueUpdate);
    await updateIssues(issueUpdate, dispatch);
    if (window.location.href.includes('projects/board') >= 0) {
      if (currentSprint) {
        fetchBoard({
          idSprint: currentSprint.id,
          idEpic: null,
          type: 0
        }, dispatchBoard);
      }
    } else {
      fetchIssue(project.id, dispatch);
    }
    createToast("success", "Update issue successfully!");
    setShow(false);
  };
  // handle close edit by click outside
  const handleCloseEditByClickOutside = async (e) => {
    if (!e.target.closest(".content")) {
      if (
        issueUpdate.summary === valuesStore.summary &&
        issueUpdate.description === valuesStore.description &&
        issueUpdate.dateStarted === valuesStore.dateStarted &&
        issueUpdate.dateEnd === valuesStore.dateEnd
      ) {
        setShow(false);
        return;
      }
      console.log('issue update', issueUpdate);
      await updateIssues(issueUpdate, dispatch);
      if (window.location.href.includes('projects/board') >= 0) {
        if (currentSprint) {
          fetchBoard({
            idSprint: currentSprint.id,
            idEpic: null,
            type: 0
          }, dispatchBoard);
        }
      } else {
        fetchIssue(project.id, dispatch);
      }
      createToast("success", "Update issue successfully!");
      setShow(false);
    }
  };
  // current epic
  const currentEpic = issueEpics.find(
    (item) => item.id === issue.id_Parent_Issue
  );
  // handle values change
  const handleValuesChange = (e) => {
    if (e.target.name === "summary") {
      setValues({
        ...values,
        [e.target.name]: e.target.value,
      });
    } else if (e.target.name === "description") {
      setValues({
        ...values,
        [e.target.name]: e.target.value,
      });
    } else if (e.target.name === "dateStarted") {
      setValues({
        ...values,
        [e.target.name]: e.target.value,
      });
    } else if (e.target.name === "dateEnd") {
      setValues({
        ...values,
        [e.target.name]: e.target.value,
      });
    }
  };
  // useEffect
  useEffect(() => {
    setValuesStore({
      summary: values.summary,
      description: values.description,
      dateStarted: values.dateStarted,
      dateEnd: values.dateEnd,
    });
  }, [issue]);
  // get child issue
  useEffect(() => {
    axios
      .get(
        `https://localhost:5001/api/Issue/GetIssueByIdParent?IdProject=${project.id}&IdParent=${issue.id}`
      )
      .then((resp) => {
        if (resp.status === 200) {
          return resp.data;
        }
      })
      .then((data) => {
        setChildIssues(data);
      })
      .catch((err) => console.log(err));
  }, [project, issue]);
  // handle toggle epic
  const handleToggleEpic = (e) => {
    if (e.target.matches(".epic-dropdown")) {
      setShowEpic((prev) => !prev);
    } else {
      return;
    }
  };
  // handle choose epic
  const handleChooseEpic = async (epic) => {
    const issueUpdate = { ...issue };
    issueUpdate.id_Parent_Issue = epic.id;
    await updateIssues(issueUpdate, dispatch);
    createToast("success", `Update epic successfully!`);
    if (window.location.href.includes('projects/board') >= 0) {
      fetchBoard({
        idSprint: currentSprint.id,
        idEpic: null,
        type: 0
      }, dispatchBoard);
    } else {
      fetchIssue(project.id, dispatch);
    }
  };
  // handle remove epic
  const handleRemoveEpic = () => {
    const issueUpdate = { ...issue };
    issueUpdate.id_Parent_Issue = null;
    updateIssues(issueUpdate, dispatch);
    createToast("success", "Remove epic successfully!");
    setTimeout(() => {
      fetchIssue(project.id, dispatch);
    }, 500);
  };

  const showCKEditorCMTClick = () => {
    setShowCKEditorCMT(true);
  };
  const hiddenCKEditorCMTClick = () => {
    setShowCKEditorCMT(false);
  };
  return (
    <ModalBase
      containerclassName="fixed inset-0 z-10 flex items-center justify-center"
      bodyClassname="relative content-modal"
      onClose={handleCloseEditByClickOutside}
    >
      <label htmlFor={`close-option-${issue.id}`}>
        <div
          className="have-y-scroll h-[80vh] overflow-auto bg-white  mb-10 overflow-x-hidden
        flex flex-col flex-[2]  mx-4 relative p-5 rounded-md"
        >
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
          <LinkIssueSelectbox
            project={project}
            issue={issue}
            showLinkIssue={showLinkIssue}
            setShowLinkIssue={setShowLinkIssue}
          />
          <div className="flex items-start justify-between">
            {issue.id_IssueType !== 1 && (
              <div className="flex items-center">
                <div
                  onClick={handleToggleEpic}
                  className="epic-dropdown relative z-10 flex items-center gap-x-2 p-2 rounded
                            cursor-pointer bg-[#8777D9] bg-opacity-20 hover:bg-opacity-50"
                >
                  <FontAwesomeIcon
                    size="1x"
                    className="pointer-events-none mx-1 p-[0.2rem] text-white text-[10px] inline-block bg-[#904ee2]"
                    icon={faBolt}
                  />
                  <span className="pointer-events-none">
                    {currentEpic ? currentEpic.summary : "Add epic"}
                  </span>
                  <span className="inline-block w-5 h-5 pointer-events-none">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      fill="none"
                      viewBox="0 0 24 24"
                      stroke="currentColor"
                      strokeWidth={2}
                    >
                      <path
                        strokeLinecap="round"
                        strokeLinejoin="round"
                        d="M19 9l-7 7-7-7"
                      />
                    </svg>
                  </span>
                  {showEpic && (
                    <div className="have-y-scroll absolute w-fit max-h-[150px] overflow-auto p-2 rounded bg-white shadow-md shadow-[#8777D9] left-0 top-[calc(100%+10px)]">
                      {issueEpics.length > 0 &&
                        issueEpics
                          .filter(
                            (epicItem) => epicItem.id !== issue.id_Parent_Issue
                          )
                          .map((item) => (
                            <div
                              onClick={() => handleChooseEpic(item)}
                              className="w-[150px] mb-2 p-3 bg-white rounded shadow-md font-semibold
                                            hover:bg-[#8777D9] hover:text-white"
                              key={item.id}
                            >
                              {item.summary}
                            </div>
                          ))}
                      {issue.id_Parent_Issue &&
                        issue.id_Parent_Issue !==
                        "00000000-0000-0000-0000-000000000000" && (
                          <div
                            onClick={handleRemoveEpic}
                            className="flex items-center gap-x-2 w-[150px] mb-2 p-3 bg-red-500 text-white rounded shadow-md font-semibold"
                          >
                            <span className="inline-block w-5 h-5">
                              <svg
                                xmlns="http://www.w3.org/2000/svg"
                                fill="none"
                                viewBox="0 0 24 24"
                                stroke="currentColor"
                                strokeWidth={2}
                              >
                                <path
                                  strokeLinecap="round"
                                  strokeLinejoin="round"
                                  d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"
                                />
                              </svg>
                            </span>
                            <span>Remove epic</span>
                          </div>
                        )}
                    </div>
                  )}
                </div>
              </div>
            )}
            <div className="flex items-center ml-auto gap-x-2">
              <OptionsEditIssue
                issue={issue}
                setShowAttachment={setShowAttachment}
                setShowAddchild={setShowAddchild}
                setShowLinkIssue={setShowLinkIssue}
              />
              <div
                onClick={handleCloseEditByButton}
                className="flex items-center justify-center w-6 h-6 text-gray-500 transition-all rounded-full cursor-pointer hover:bg-primary hover:bg-opacity-30"
              >
                <span className="inline-flex items-center justify-center w-4 h-4">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 20 20"
                    fill="currentColor"
                  >
                    <path
                      fillRule="evenodd"
                      d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                      clipRule="evenodd"
                    />
                  </svg>
                </span>
              </div>
            </div>
          </div>
          <div className="my-4 text-2xl font-bold">
            <input
              spellCheck={false}
              value={values.summary}
              onChange={handleValuesChange}
              name="summary"
              className="w-full p-2 border-2 border-transparent rounded-md outline-none focus:border-primary"
              type="text"
            />
          </div>
          <div className="flex items-center mb-4 gap-x-2">
            <Stage
              currentSprint={currentSprint}
              project={project}
              issue={issue}
              stage={stage}
            />
            {issue?.isFlagged === 1 && (
              <div className="flex items-center w-fit">
                <span className="text-[#EF0000] w-5 h-5">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 20 20"
                    fill="currentColor"
                  >
                    <path
                      fillRule="evenodd"
                      d="M3 6a3 3 0 013-3h10a1 1 0 01.8 1.6L14.25 8l2.55 3.4A1 1 0 0116 13H6a1 1 0 00-1 1v3a1 1 0 11-2 0V6z"
                      clipRule="evenodd"
                    />
                  </svg>
                </span>
                Flagged
              </div>
            )}
          </div>
          <div className="m-1 font-bold">Description</div>
          <div>
            <TextBox
              spellCheck={false}
              value={values.description}
              onChange={handleValuesChange}
              placeholder="Enter description..."
              name="description"
            />
          </div>
          <Attachment issue={issue} />
          <ModalProvider project={project}>
            <ChildIssue project={project} issues={childIssues} />
          </ModalProvider>
          <ModalProvider project={project}>
            <LinkIssue project={project} issue={issue} />
          </ModalProvider>
          <div className='detail'>
            <div className='item w-full h-13 p-1 bg-white px-4 mt-[-1px] border-solid border border-[#ccc] border-b-0 flex justify-between items-center'>
              <div className='flex items-center justify-between w-full h-8 my-2'>
                <p className='m-1 font-bold'>
                  Detail
                </p>
              </div>
            </div>
            <div className="item w-full h-13 p-1 bg-white px-4 mt-[-1px] border-solid border-[1px] border-[#ccc] flex justify-between items-center flex-wrap">
              <div className="w-[40%] h-13 my-4">Assignee</div>
              <div className="w-[60%]">
                <Assignee members={members} project={project} issue={issue} />
              </div>
              <div className="w-[40%] h-13 my-4">Labels</div>
              <div className="w-[60%]">
                <Label project={project} issue={issue} currentSprint={currentSprint} />
              </div>
              <div className="w-[40%] h-13 my-4">Sprint</div>
              <div className="w-[60%]">{currentSprint?.sprintName}</div>
              <div className="w-[40%] h-13 my-4">Story point estimate</div>
              <div className="w-[60%]">{issue?.story_Point_Estimate}</div>
              <div className="w-[40%] h-13 my-4">Date started</div>
              <div className="w-[60%]">
                <input
                  name="dateStarted"
                  onChange={handleValuesChange}
                  value={values.dateStarted}
                  type="date"
                />
              </div>
              <div className="w-[40%] h-13 my-4">Date end</div>
              <div className="w-[60%]">
                <input
                  name="dateEnd"
                  onChange={handleValuesChange}
                  value={values.dateEnd}
                  type="date"
                />
              </div>

              <div className="w-[40%] h-13 my-4">Reporter</div>
              <div className="w-[60%]">
                <Reporter members={members} project={project} issue={issue} />
              </div>
            </div>
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
  );
}

export default memo(EditArchiveIssuePopup);

// child issue
function ChildIssue({ issues, project }) {
  const [, dispatchIssue] = useListIssueContext();
  const {
    modal: [, setShow,],
    item: [, setIssue]
  } = useModalContext();

  // handle remove child
  const handleRemoveChild = async (child) => {
    child.id_Parent_Issue = NIL;
    await updateIssues(child, dispatchIssue);
    fetchIssue(project.id, dispatchIssue);
    createToast('success', 'Remove child successfully')
  }
  // handle show edit
  const handleShowEdit = (issueEdit) => {
    setIssue(issueEdit);
    setShow(true);
  }

  return (
    <div className="child-issue">
      <p className="title">Child issue</p>
      <div className="list-issue have-y-scroll">
        {issues.length === 0 && <p>No child issue</p>}
        {issues.length > 0 &&
          issues.map((issue) => (
            <div onClick={() => handleShowEdit(issue)} key={issue.id} className="issue-item">
              <div className="img">
                <img
                  src={
                    issueTypes.find((item) => item.value === issue.id_IssueType)
                      .thumbnail
                  }
                  alt=""
                />
              </div>
              <span className="summary">{issue.summary}</span>
              <span
                onClick={() => handleRemoveChild(issue)}
                title="Remove"
                className="delete-child"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                  strokeWidth={2}
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"
                  />
                </svg>
              </span>
            </div>
          ))}
      </div>
    </div>
  );
}
// link issue
function LinkIssue({ project, issue }) {
  const {
    modal: [, setShow,],
    item: [, setIssue]
  } = useModalContext();
  const [{ issueNormals }, dispatchIssue] = useListIssueContext();
  const issueLinked = useMemo(() => {
    return issueNormals.filter(item => item.id_Linked_Issue === issue.id);
  }, [issueNormals, issue])
  // handle remove link
  const handleRemoveChild = async (issueRemove) => {
    issueRemove.id_Linked_Issue = NIL;
    await updateIssues(issueRemove, dispatchIssue);
    fetchIssue(project.id, dispatchIssue);
    createToast('success', 'Remove link issue successfully!');
  }
  const handleShowEdit = (issueEdit) => {
    setIssue(issueEdit);
    setShow(true);
  }

  return (
    <div className="show-link">
      <p className="title">Linked issue</p>
      <div className="list-issue have-y-scroll">
        {issueLinked.length === 0 && <p>No link issue</p>}
        {issueLinked.length > 0 &&
          issueLinked.map((item) => (
            <div onClick={() => handleShowEdit(item)} key={item.id} className="issue-item">
              <div className="img">
                <img
                  src={
                    issueTypes.find((t) => t.value === item.id_IssueType).thumbnail
                  }
                  alt=""
                />
              </div>
              <span className="summary">{item.summary}</span>
              <span
                onClick={() => handleRemoveChild(item)}
                title="Remove"
                className="delete-child"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                  strokeWidth={2}
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"
                  />
                </svg>
              </span>
            </div>
          ))}
      </div>
    </div>
  )
}
// attachment
function Attachment({ issue }) {
  const downloadRef = useRef();
  // handle download
  const handleDownload = () => {
    const lastBacklashIndex = issue.attachment_Path.lastIndexOf("/");
    const fileName = issue.attachment_Path.slice(lastBacklashIndex + 1);
    const path = `${BASE_URL}/api/Issue/download?fileName=${fileName}`;
    if (fileName) {
      downloadRef.current.href = path;
      downloadRef.current.click();
    }
  };

  return (
    <div className="attach">
      <p className="title">Attachment</p>
      {!issue.attachment_Path ? (
        <p>No attachment</p>
      ) : (
        <div className="download">
          <div className="image">
            <img src={issue.attachment_Path} alt="" />
          </div>
          <a ref={downloadRef} hidden href="/">
            download
          </a>
          <span onClick={handleDownload} className="btn-download">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              strokeWidth={2}
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-4l-4 4m0 0l-4-4m4 4V4"
              />
            </svg>
          </span>
        </div>
      )}
    </div>
  );
}
// text area
function TextBox({ value, onChange, ...props }) {
  const nodeRef = useRef();
  const [height, setHeight] = useState("auto");
  const [text, setText] = useState(value);
  // handle change
  const handleChange = (e) => {
    setText(e.target.value);
    setHeight("auto");
    onChange(e);
  };
  useEffect(() => {
    if (text) {
      setHeight(nodeRef.current.scrollHeight || 'auto');
    }
  }, [text])
  return (
    <textarea
      {...props}
      ref={nodeRef}
      style={{ height: height }}
      value={text}
      onChange={handleChange}
      className="w-full p-2 overflow-hidden border-2 border-transparent rounded-md outline-none resize-none focus:border-primary"
    ></textarea>
  );
}
// Stage
function Stage({ project, issue, stage, currentSprint }) {
  const [{ stages }, dispatchStage] = useStageContext();
  const [, dispatchBoard] = useBoardContext();
  const [show, setShow] = useState(false);
  const [, dispatchIssue] = useListIssueContext();
  // toggle
  const toggle = (e) => {
    if (e.target.matches(".btn-toggle")) {
      setShow((prev) => !prev);
    }
  };
  // handle change stage
  const handleChangeStage = async (stage) => {
    if (stage) {
      issue.id_Stage = stage.id;
      await updateIssues(issue, dispatchIssue);
      if (window.location.href.includes('projects/board') >= 0) {
        fetchBoard({
          idSprint: currentSprint.id,
          idEpic: null,
          type: 0
        }, dispatchBoard);
      } else {
        fetchIssue(project.id, dispatchIssue);
      }
      createToast('success', 'Update stage successfully');
    }
  };

  return (
    <div onClick={toggle} className='relative flex items-center justify-center px-4 py-2 transition-all rounded cursor-pointer btn-toggle gap-x-2 bg-gray-main hover:bg-gray-200'>
      <span className='inline-block font-semibold uppercase pointer-events-none'>{123}</span>
      <span className='inline-block w-5 h-5 pointer-events-none text-inherit'>
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
          <path fillRule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clipRule="evenodd" />
        </svg>
      </span>
      {show && (
        <div className="absolute w-[110%] z-10 top-[105%] left-0 bg-gray-main rounded shadow-md">
          {
            stages.length > 0 &&
            stages.map(item => {
              return (
                item.id !== stage.id
                  ? <p key={item.id} onClick={() => handleChangeStage(item)} className='p-2 uppercase cursor-pointer hover:bg-gray-200'>{123}</p>
                  : null
              )

            })
          }
        </div>
      )}
    </div>
  );
}
// Assign
function Assignee({ members, project, issue }) {
  const [, dispathIssue] = useListIssueContext();
  const [show, setShow] = useState(false);

  // current assignee
  const currentAssignee = useMemo(() => {
    return members.find((item) => item.id === issue.id_Assignee);
  }, [members, issue]);
  // toggle
  const toggle = (e) => {
    if (e.target.matches(".toggle")) {
      setShow((prev) => !prev);
    }
  };
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
    <div
      onClick={toggle}
      className="relative z-10 w-6 h-6 bg-white rounded-full cursor-pointer toggle"
    >
      {currentAssignee ? (
        <span className="inline-flex items-center justify-center w-full h-full text-white bg-orange-500 rounded-full pointer-events-none">
          {
            currentAssignee.avatar_Path ?
              (<img className="inline-block w-full h-full rounded-full" src={currentAssignee.avatar_Path} alt="" />) :
              (currentAssignee?.userName?.slice(0, 1))
          }
        </span>
      ) : (
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
      )}
      {show && (
        <div
          style={{ transform: "translateX(-25%)" }}
          className="absolute top-[105%] left-0 shadow-md bg-white max-h-[150px] overflow-auto have-y-scroll"
        >
          <div
            onClick={() => handleSelectMember(null)}
            className="flex items-center p-2"
          >
            Unassignee
          </div>
          {members.length > 0 &&
            members.map((item) => (
              <div
                onClick={() => handleSelectMember(item)}
                key={item.id}
                className={`p-2 flex items-center hover:bg-gray-main ${issue.id_Assignee === item.id
                  ? "bg-orange-500 text-white pointer-events-none"
                  : ""
                  }`}
              >
                {item.userName}
              </div>
            ))}
        </div>
      )}
    </div>
  );
}
// Reporter
function Reporter({ members, project, issue }) {
  const [, dispathIssue] = useListIssueContext();
  const [show, setShow] = useState(false);

  // current assignee
  const currentAssignee = useMemo(() => {
    return members.find((item) => item.id === issue.id_Reporter);
  }, [members, issue]);
  // toggle
  const toggle = (e) => {
    if (e.target.matches(".toggle")) {
      setShow((prev) => !prev);
    }
  };
  // handle select member
  const handleSelectMember = async (member) => {
    issue.id_Reporter = member.id;
    await updateIssues(issue, dispathIssue);
    fetchIssue(project.id, dispathIssue);
    createToast('success', 'Change reporter sucessfully');
  }

  return (
    <div
      onClick={toggle}
      className="relative z-10 w-6 h-6 bg-white rounded-full cursor-pointer toggle"
    >
      {currentAssignee ? (
        <span className="inline-flex items-center justify-center w-full h-full text-white bg-orange-500 rounded-full pointer-events-none">
          {
            currentAssignee.avatar_Path ?
              (<img className="inline-block w-full h-full rounded-full" src={currentAssignee.avatar_Path} alt="" />) :
              (currentAssignee?.userName?.slice(0, 1))
          }
        </span>
      ) : (
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
      )}
      {show && (
        <div
          style={{ transform: "translateX(-25%)" }}
          className="absolute top-[105%] left-0 shadow-md bg-white max-h-[150px] overflow-auto have-y-scroll"
        >
          {members.length > 0 &&
            members.map((item) => (
              <div
                onClick={() => handleSelectMember(item)}
                key={item.id}
                className={`p-2 flex items-center hover:bg-gray-main ${issue.id_Reporter === item.id
                  ? "bg-orange-500 text-white pointer-events-none"
                  : ""
                  }`}
              >
                {item.userName}
              </div>
            ))}
        </div>
      )}
    </div>
  );
}
// Label
function Label({ project, issue, currentSprint }) {
  const [{ labels }] = useLabelContext();
  const [, dispatchIssue] = useListIssueContext();
  const [, dispatchBoard] = useBoardContext();
  const [show, setShow] = useState(false);
  const currentLablel = useMemo(() => {
    return labels.find(item => item.id === issue.id_Label)
  }, [labels, issue])
  // handle show
  const handleShow = (e) => {
    if (e.target.matches('.btn-label')) {
      setShow(prev => !prev);
    }
  }
  // handle select label
  const handleSelectLabel = async (labelSelected) => {
    try {
      const resp = await axios.put(`${BASE_URL}/api/Issue/AddLabel`, {
        idIssue: issue.id,
        idLabel: labelSelected.id
      })
      if (resp.status === 200) {
        if (window.location.href.includes('/projects/board')) {
          fetchIssue(project.id, dispatchIssue);
          fetchBoard({
            idSprint: currentSprint.id,
            idEpic: null,
            type: 0
          }, dispatchBoard);
        } else if (window.location.href.includes('/projects/backlog')) {
          fetchIssue(project.id, dispatchIssue);
        }
      }
    } catch (error) {
      console.log(error);
    }
  }

  return (
    <div onClick={handleShow} className="relative w-fit">
      <p className="p-2 rounded cursor-pointer btn-label w-fit hover:bg-gray-main">{currentLablel ? currentLablel.name : 'None'}</p>
      {
        show &&
        <div className="bg-white shadow-md border border-gray-main absolute top-full left-0 rounded overflow-hidden min-w-[100px]">
          <p
            onClick={() => handleSelectLabel({ id: NIL })}
            className={`p-2 cursor-pointer hover:bg-gray-main w-full
          ${!currentLablel ? 'bg-orange-400 text-white pointer-events-none' : ''}`}
          >None</p>
          {
            labels.length > 0 &&
            labels.map(item => (
              <p
                key={item.id}
                onClick={() => handleSelectLabel(item)}
                className={`p-2 cursor-pointer hover:bg-gray-main w-full ${currentLablel?.id === item.id ? 'bg-orange-400 text-white pointer-events-none' : ''}`}>{item.name}</p>
            )
            )
          }
        </div>
      }
    </div>
  )
}

import React, { useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getProjects, updateProjects } from "../../redux/apiRequest";
import "./ContainerRoadmap.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faAngleDown,
  faSquareCheck,
  faTimes,
  faAngleRight,
  faFlag,
  faBolt,
  faCheck,
  faLock,
  faEye,
  faThumbsUp,
  faTimeline,
  faPaperclip,
  faLink,
  faPlus,
  faArrowDownShortWide,
  faArrowDownWideShort,
} from "@fortawesome/free-solid-svg-icons";
import useModal from "../../hooks/useModal";
import { useListIssueContext } from "../../contexts/listIssueContext";
import { v4 } from "uuid";

const ContainerRoadmap = ({ project }) => {
  const { id } = project;
  const [
    {
      issueEpics,
      issueNormals,
      filters: { epics, type },
    },
    dispatchIssue,
  ] = useListIssueContext();
  const { currentUser } = useSelector((state) => state.auth.login);
  const dispatch = useDispatch();
  const [show, setShow, handleClose] = useModal();
  const timer = useRef();

  const [search, setSearch] = useState("");
  const [showEpic, setShowEpic] = useState(false);
  const [showType, setShowType] = useState(false);
  const [showMembers, setShowMembers] = useState(false);
  const [members, setMembers] = useState([]);
  const [focus, setFocus] = useState(false);
  const inputRef = useRef();
  console.log(project);
  const handleFocus = () => {
    setFocus(true);
  };
  const handleBlur = () => {
    setFocus(false);
  };
  // handle click star
  const handleClickStar = () => {
    const putData = () => {
      const dataPut = {
        ...project,
        id_Updator: currentUser.id,
        updateDate: new Date(),
      };
      if (project.isStared === 0) {
        dataPut.isStared = 1;
      } else {
        dataPut.isStared = 0;
      }
      console.log(dataPut);
      updateProjects(dispatch, dataPut);
      getProjects(dispatch, currentUser.id);
    };
    putData();
  };
  // handle change show members
  const handleChangeShowMembers = (e) => {
    if (e.target.matches(".js-changeshow")) {
      setShowMembers((prev) => !prev);
    }
  };
  return (
    <div className="container">
      <div className="top">
        <div className="navigate">
          <span>Projects</span>
          <span>/</span>
          <span>{project.name}</span>
        </div>
        <div className="wrap-key">
          <h3 className="key">{project.key} Roadmap</h3>
          {project.isStared ? (
            <svg
              onClick={handleClickStar}
              xmlns="http://www.w3.org/2000/svg"
              className="w-8 h-8 cursor-pointer"
              viewBox="0 0 20 20"
              fill="yellow"
            >
              <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
            </svg>
          ) : (
            <svg
              onClick={handleClickStar}
              xmlns="http://www.w3.org/2000/svg"
              className="w-8 h-8 cursor-pointer"
              fill="none"
              viewBox="0 0 24 24"
              stroke="#ccc"
              strokeWidth={2}
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                d="M11.049 2.927c.3-.921 1.603-.921 1.902 0l1.519 4.674a1 1 0 00.95.69h4.915c.969 0 1.371 1.24.588 1.81l-3.976 2.888a1 1 0 00-.363 1.118l1.518 4.674c.3.922-.755 1.688-1.538 1.118l-3.976-2.888a1 1 0 00-1.176 0l-3.976 2.888c-.783.57-1.838-.197-1.538-1.118l1.518-4.674a1 1 0 00-.363-1.118l-3.976-2.888c-.784-.57-.38-1.81.588-1.81h4.914a1 1 0 00.951-.69l1.519-4.674z"
              />
            </svg>
          )}
        </div>
        <div className="actions">
          <div className="actions">
            <div className={`wrap-input ${focus ? "expand" : ""}`}>
              <input
                value={search}
                onChange={(e) => setSearch(e.target.value)}
                placeholder={focus ? "Search this board" : ""}
                ref={inputRef}
                type="text"
              />
              <svg
                xmlns="http://www.w3.org/2000/svg"
                className="icon"
                viewBox="0 0 20 20"
                fill="#ccc"
              >
                <path
                  fillRule="evenodd"
                  d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z"
                  clipRule="evenodd"
                />
              </svg>
            </div>
            <div className="members">
              <div className="avatar">
                <img
                  src="https://images.unsplash.com/photo-1644982647708-0b2cc3d910b7?ixlib=rb-1.2.1&ixid=MnwxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHwxfHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=500&q=60"
                  alt=""
                />
              </div>
              <div
                onClick={handleChangeShowMembers}
                className="js-changeshow avatar relative flex items-center justify-center p-2 bg-[#ccc] cursor-pointer"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  className="w-5 h-5 pointer-events-none"
                  viewBox="0 0 20 20"
                  fill="#999"
                >
                  <path
                    fillRule="evenodd"
                    d="M15.707 4.293a1 1 0 010 1.414l-5 5a1 1 0 01-1.414 0l-5-5a1 1 0 011.414-1.414L10 8.586l4.293-4.293a1 1 0 011.414 0zm0 6a1 1 0 010 1.414l-5 5a1 1 0 01-1.414 0l-5-5a1 1 0 111.414-1.414L10 14.586l4.293-4.293a1 1 0 011.414 0z"
                    clipRule="evenodd"
                  />
                </svg>
                {showMembers && (
                  <div className="current-members">
                    {members.length > 0 ? (
                      members.map((item) => (
                        <div
                          key={v4()}
                          className="w-full flex justify-between items-center px-[10px]"
                        >
                          <span className="text-primary">{item.userName}</span>
                          <div
                            onClick={() => handleDeleteMember(item.id)}
                            className="text-[#ccc]  hover:text-red-500 "
                          >
                            remove
                          </div>
                        </div>
                      ))
                    ) : (
                      <p className="text-sm text-center text-[#999]">
                        Project has no members
                      </p>
                    )}
                  </div>
                )}
              </div>
              <div onClick={handleClickAdd} className="add-member">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  className="icon"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="#999"
                  strokeWidth={2}
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    d="M18 9v3m0 0v3m0-3h3m-3 0h-3m-2-5a4 4 0 11-8 0 4 4 0 018 0zM3 20a6 6 0 0112 0v1H3v-1z"
                  />
                </svg>
              </div>
            </div>
          </div>
          <div className="filters">
            <div
              onClick={handleCloseEpic}
              style={
                showEpic ? { backgroundColor: "#8777D9", color: "white" } : {}
              }
              className="epic"
            >
              <span className={`epic-number ${showEpic ? "active" : ""}`}>
                {epics.length}
              </span>
              <span className="pointer-events-none title">Epic</span>
              <span className="pointer-events-none icon">
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

              <div
                style={
                  showEpic
                    ? { transform: "translateX(-40%) scale(1)", opacity: 1 }
                    : {}
                }
                className="epic-dropdown have-y-scroll p-2 w-[300px] h-[200px] overflow-y-auto mx-4 bg-white rounded-[5px] flex items-center flex-col"
              >
                <div className="flex justify-between w-full px-4 py-2">
                  <span className="font-bold text-lg text-[#8777D9]">Epic</span>
                </div>
                <div
                  onClick={() => handleChooseEpic("issues without epic")}
                  className={`w-full p-3 mb-2 flex items-center font-semibold
                            shadow-md rounded-[5px] ${
                              epics.includes("issues without epic")
                                ? "bg-[#8777D9] text-white"
                                : "bg-white"
                            }`}
                >
                  issues without epic
                </div>
                {issueEpics.length > 0 &&
                  issueEpics.map((item) => (
                    <div
                      key={v4()}
                      onClick={() => handleChooseEpic(item.id)}
                      className={`w-full p-3 flex flex-col font-semibold shadow-md rounded-[5px] mb-2
                                ${
                                  epics.includes(item.id)
                                    ? "bg-[#8777D9] text-white"
                                    : "bg-white"
                                }`}
                    >
                      <div className="flex items-center">
                        <FontAwesomeIcon
                          size="1x"
                          className="inline-block px-2"
                          icon={faAngleRight}
                        />
                        <div className="h-5 w-5 inline-block bg-[#d0c6ff] rounded-[5px] mx-2"></div>
                        {item.summary}
                      </div>
                      <div className="h-2 w-full bg-[#ddd] rounded-[5px] my-2 relative">
                        <div
                          className="absolute top-0 left-0  bottom-0 bg-blue-600 rounded-[10px]"
                          style={{ width: "40%" }}
                        ></div>
                      </div>
                    </div>
                  ))}
                <CreateComponent
                  idIssueType={1}
                  project={project}
                  createWhat={"epic"}
                />
              </div>
            </div>
            <div
              style={
                showType ? { backgroundColor: "#4BADE8", color: "white" } : {}
              }
              onClick={handleCloseType}
              className="type"
            >
              <span className={`type-number ${showType ? "active" : ""}`}>
                {type.length}
              </span>
              <span className="pointer-events-none title">Type</span>
              <span className="pointer-events-none icon">
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

              <div
                style={
                  showType
                    ? { transform: "translateX(-15%) scale(1)", opacity: 1 }
                    : {}
                }
                className="type-dropdown"
              >
                {issueTypes.length > 0 &&
                  issueTypes.map((item) => (
                    <div
                      key={item.id}
                      onClick={() => handleChooseType(item.value)}
                      className={`flex items-center gap-x-2 p-1 rounded hover:bg-gray-300 mb-2 ${
                        type.includes(item.value) ? "bg-[#e2e2e2]" : "bg-white"
                      }`}
                    >
                      <div className="w-5 h-5">
                        <img
                          className="block object-cover w-full h-full rounded-md"
                          src={item.thumbnail}
                          alt=""
                        />
                      </div>
                      <span className="inline-block">{item.title}</span>
                    </div>
                  ))}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ContainerRoadmap;

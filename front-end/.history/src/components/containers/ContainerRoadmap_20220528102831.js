import React, { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getProjects, updateProjects } from "../../redux/apiRequest";
import "./ContainerRoadmap.scss";
import { fetchIssue } from "../../reducers/listIssueReducer";
import {
  CHANGE_FILTERS_EPIC,
  CHANGE_FILTERS_NAME,
  CHANGE_FILTERS_TYPE,
} from "../../reducers/actions";
import CreateComponent from "../CreateComponent";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAngleRight } from "@fortawesome/free-solid-svg-icons";
import useModal from "../../hooks/useModal";
import { useListIssueContext } from "../../contexts/listIssueContext";
import { v4 } from "uuid";
import { BASE_URL, issueTypes } from "../../util/constants";
import axios from "axios";
import AddMemberPopup from "../popup/AddMemberPopup";
import useHover from "../../hooks/useHover";
import RoadmapItem from "./RoadmapItem";
import Roadmap from "../roadmap/Roadmap";
import {
  MembersProvider,
  useMembersContext,
} from "../../contexts/membersContext";
import { fetchMembers } from "../../reducers/membersReducer";
import { fetchStage } from "../../reducers/stageReducer";
import { useStageContext } from "../../contexts/stageContext";
import Progress from "../progress/Progress";

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

  const [hoverRef, isHovered] = useHover();
  const timer = useRef();
  const { dispatch: dispatchMember } = useMembersContext();
  const [{ stages }, dispatchStage] = useStageContext();

  useEffect(() => {
    if (project && project.id) {
      fetchStage(project.id, dispatchStage);
    }
  }, [project]);
  useEffect(() => {
    if (project && project.id) {
      fetchMembers(project.id, dispatchMember);
    }
  }, [project]);

  const [search, setSearch] = useState("");
  const [showEpic, setShowEpic] = useState(false);
  const [showType, setShowType] = useState(false);
  const [showIssue, setShowIssue] = useState(false);
  const [showMembers, setShowMembers] = useState(false);
  const [members, setMembers] = useState([]);
  const [focus, setFocus] = useState(false);
  const inputRef = useRef();
  console.log(project);
  const handleFocus = () => {
    setFocus(true);
  };
  const handleshowIssue = () => {
    setShowIssue(!showIssue);
  };
  const handleBlur = () => {
    setFocus(false);
  };

  // handle change show members
  const handleChangeShowMembers = (e) => {
    if (e.target.matches(".js-changeshow")) {
      setShowMembers((prev) => !prev);
    }
  };
  // handle delete member
  const handleDeleteMember = (idUser) => {
    const deleteMemberApi = async () => {
      const resp = await axios.post(`${BASE_URL}/api/Project/RemoveMember`, {
        idProject: id,
        idUser,
      });
      if (resp.status === 200) {
        setMembers((prev) => {
          const prevCopy = [...prev];
          const index = prevCopy.findIndex((item) => item.id === idUser);
          prevCopy.splice(index, 1);
          return prevCopy;
        });
      }
      console.log("resp ~ ", resp);
    };
    deleteMemberApi();
  };
  // handle close epic
  const handleCloseEpic = (e) => {
    if (!e.target.matches(".epic")) return;
    if (!showEpic && !showType) {
      setShowEpic(true);
    } else if (!showEpic && showType) {
      setShowEpic(true);
      setShowType(false);
    } else if (showEpic) {
      setShowEpic(false);
    }
  };
  // handle close type
  const handleCloseType = (e) => {
    if (!e.target.matches(".type")) return;
    if (!showType && !showEpic) {
      setShowType(true);
    } else if (!showType && showEpic) {
      setShowType(true);
      setShowEpic(false);
    } else if (showType) {
      setShowType(false);
    }
  };
  // handle choose epic
  const handleChooseEpic = (idEpic) => {
    dispatchIssue({
      type: CHANGE_FILTERS_EPIC,
      payload: idEpic,
    });
    setTimeout(() => {
      fetchIssue(project.id, dispatchIssue);
    }, 500);
  };
  // handle choose type
  const handleChooseType = (idType) => {
    dispatchIssue({
      type: CHANGE_FILTERS_TYPE,
      payload: idType,
    });
    setTimeout(() => {
      fetchIssue(project.id, dispatchIssue);
    }, 500);
  };
  const handleClickAdd = () => {
    setShow(true);
  };
  // useEffect get issues
  useEffect(() => {
    if (project && Object.entries(project).length > 0) {
      fetchIssue(project.id, dispatchIssue);
    }
  }, [project]);
  useEffect(() => {
    const inputEl = inputRef.current;
    inputEl.addEventListener("focus", handleFocus);
    inputEl.addEventListener("blur", handleBlur);

    return () => {
      inputEl.removeEventListener("focus", handleFocus);
      inputEl.removeEventListener("blur", handleBlur);
    };
  }, []);
  useEffect(() => {
    console.log("chay vao useeffect");
    const fetchMember = async () => {
      try {
        const resp = await axios.get(
          `${BASE_URL}/api/Project/GetAllMemberByIdProject?IdProject=${project.id}`
        );
        const data = resp.data;
        setMembers(data);
      } catch (error) {
        console.log(error);
      }
    };
    if (id) {
      fetchMember();
    } else {
      console.log("id null");
    }
  }, [id, show]);
  // dispatch search
  useEffect(() => {
    if (project?.id) {
      timer.current = setTimeout(() => {
        dispatchIssue({
          type: CHANGE_FILTERS_NAME,
          payload: search,
        });
        fetchIssue(project.id, dispatchIssue);
      }, 1000);
    }
    return () => clearTimeout(timer.current);
  }, [search]);

  return (
    <div className="container">
      <div className="top">
        {show && (
          <AddMemberPopup
            project={project}
            setShow={setShow}
            onClose={handleClose}
          ></AddMemberPopup>
        )}
        <div className="navigate">
          <span>Projects</span>
          <span>/</span>
          <span>{project.name}</span>
        </div>
        <div className="wrap-key">
          <h3 className="key">{project.key} Roadmap</h3>
        </div>
        <div className="actions">
          <div className="actions">
            <div className={`wrap-input ${focus ? "expand" : ""}`}>
              <input
                value={search}
                onChange={(e) => setSearch(e.target.value)}
                placeholder={focus ? "Search roadmap" : ""}
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
                  <div className="current-members z-50">
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
                className="epic-dropdown w-[300px] z-[9999] have-y-scroll p-2  h-[200px] overflow-y-auto  bg-white rounded-[5px] flex items-center flex-col"
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
                      className={`w-full p-3 relative z-40 flex flex-col font-semibold shadow-md rounded-[5px] mb-2
                                ${
                                  epics.includes(item.id)
                                    ? "bg-[#8777D9] text-white"
                                    : "bg-white"
                                }`}
                    >
                      <div className="flex items-center">
                        <div className="h-5 w-5 inline-block bg-[#d0c6ff] rounded-[5px] mx-2"></div>
                        {item.summary}
                      </div>
                      {/* <Progress done={60} /> */}
                      {/* <div className="h-2 w-full bg-[#ddd] rounded-[5px] my-2 relative">
                        <div
                          className="absolute z-50 top-0 left-0  bottom-0 bg-blue-600 rounded-[10px]"
                          style={{ width: "40%" }}
                        ></div>
                      </div> */}
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
              className=" type"
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
                className="z-50 type-dropdown"
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
      <div className="flex overflow-x-auto have-y-scroll w-full  h-[470px]">
        <div className="border-2 overflow-y-auto have-y-scroll  border-slate-200  outline-none out basis-[30%]">
          <div className=" w-full epic-dropdown have-y-scroll p-2  have-y-scroll  overflow-y-auto mx-4 bg-white rounded-[5px] flex items-center flex-col">
            <div className="flex justify-between w-full px-4 py-2 border-b-2 border-slate-200">
              <span className="text-lg font-bold text-slate-600">Epic</span>
            </div>
            {issueEpics.length > 0 &&
              issueEpics.map((item) => (
                <RoadmapItem
                  key={v4()}
                  item={item}
                  project={project}
                  epic={item}
                />
              ))}
            <CreateComponent
              idIssueType={1}
              project={project}
              createWhat={"epic"}
            />
          </div>
        </div>
        <div className="basis-[70%] relative">
          <Roadmap />
        </div>
      </div>
    </div>
  );
};

export default ContainerRoadmap;

import React, { useEffect, useRef, useState } from "react";
import "./TopDetail.scss";
import { useSelector, useDispatch } from "react-redux";
import useModal from "../../hooks/useModal";
import { getProjects, updateProjects } from "../../redux/apiRequest";
import { fetchIssue } from "../../reducers/listIssueReducer";
import {
  CHANGE_FILTERS_EPIC,
  CHANGE_FILTERS_NAME,
  CHANGE_FILTERS_TYPE,
} from "../../reducers/actions";
import AddMemberPopup from "../popup/AddMemberPopup";
import { v4 } from "uuid";
import { useListIssueContext } from "../../contexts/listIssueContext";
import { deleteMembers, fetchMembers } from "../../reducers/membersReducer";
import { useMembersContext } from "../../contexts/membersContext";
import { documentHeight, issueTypes } from "../../util/constants";
import FilterEpicSelectBox from "../selectbox/FilterEpicSelectBox";
import FilterTypeSelectBox from "../selectbox/FilterTypeSelectBox";
import FilterLabelSelectBox from "../selectbox/FilterLabelSelectBox";
import useClickOutSide from "../../hooks/useClickOutSide";

const secondThirdScreen = (documentHeight * 2) / 3;

function TopDetail({ project }) {
  const [
    {
      issueEpics,
      filters: { epics, type },
    },
    dispatchIssue,
  ] = useListIssueContext();
  const {
    state: { members },
    dispatch: dispatchMembers,
  } = useMembersContext();
  const { currentUser } = useSelector((state) => state.auth.login);
  const dispatch = useDispatch();
  const [show, setShow, handleClose] = useModal();
  const timer = useRef();

  const [search, setSearch] = useState("");
  const [coordEpic, setCoordEpic] = useState({});
  const [coordType, setCoordType] = useState({});
  const [coordLabel, setCoordLabel] = useState({});
  const [showEpic, setShowEpic, handleCloseEpic] = useModal();
  const [showType, setShowType, handleCloseType] = useModal();
  const [showLabel, setShowLabel, handleCloseLabel] = useModal();
  const [showMembers, setShowMembers] = useState(false);
  const [focus, setFocus] = useState(false);
  const inputRef = useRef();
  const filterEpicRef = useRef();
  const filterTypeRef = useRef();
  const filterLabelRef = useRef();
  const {
    show: showAllMembers,
    setShow: setShowAllMembers,
    nodeRef: nodeRefAllMember,
  } = useClickOutSide();

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
  const handleChangeShowAllMembers = (e) => {
    setShowAllMembers(!showAllMembers);
    // setShowMembers(false);
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
    if (project?.id) {
      fetchMembers(project.id, dispatchMembers);
    }
  }, [project?.id]);
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

  const handleClickAdd = () => {
    setShow(true);
  };
  // handle delete member
  const handleDeleteMember = async (idUser) => {
    const data = {
      idProject: project.id,
      idUser,
    };
    await deleteMembers(data, dispatchMembers);
    fetchMembers(project.id, dispatchMembers);
  };
  // handle show epic
  const handleShowFilterEpic = () => {
    const bounding = filterEpicRef.current.getBoundingClientRect();
    if (bounding) {
      setCoordEpic(bounding);
      setShowEpic(true);
    }
  };
  // handle show type
  const handleShowFilterType = () => {
    const bounding = filterTypeRef.current.getBoundingClientRect();
    if (bounding) {
      setCoordType(bounding);
      setShowType(true);
    }
  };
  // handle show filter label
  const handleShowFilterLabel = () => {
    const bounding = filterLabelRef.current.getBoundingClientRect();
    if (bounding) {
      setCoordLabel(bounding);
      setShowLabel(true);
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

  return (
    <div className="top">
      {showEpic && (
        <FilterEpicSelectBox
          handleChooseEpic={handleChooseEpic}
          onClose={handleCloseEpic}
          bodyStyle={{
            top:
              coordEpic.bottom <= secondThirdScreen
                ? coordEpic.bottom + 10
                : null,
            left: coordEpic.left - 100,
            bottom: !(coordEpic.bottom <= secondThirdScreen)
              ? documentHeight - coordEpic.top - 10
              : null,
          }}
          epics={epics}
          issueEpics={issueEpics}
          project={project}
        />
      )}
      {showType && (
        <FilterTypeSelectBox
          issueTypes={issueTypes}
          type={type}
          handleChooseType={handleChooseType}
          onClose={handleCloseType}
          bodyStyle={{
            top:
              coordType.bottom <= secondThirdScreen
                ? coordType.bottom + 10
                : null,
            left: coordType.left,
            bottom: !(coordType.bottom <= secondThirdScreen)
              ? documentHeight - coordType.top - 10
              : null,
          }}
        />
      )}
      {showLabel && (
        <FilterLabelSelectBox
          onClose={handleCloseLabel}
          bodyStyle={{
            top:
              coordLabel.bottom <= secondThirdScreen
                ? coordLabel.bottom + 10
                : null,
            left: coordLabel.left,
            bottom: !(coordLabel.bottom <= secondThirdScreen)
              ? documentHeight - coordLabel.top - 10
              : null,
          }}
        />
      )}
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
        <span>{project?.name}</span>
      </div>
      <div className="wrap-key">
        <h3 className="key">{project?.key} board</h3>
        {project?.isStared ? (
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
                  <span
                    onClick={handleChangeShowAllMembers}
                    className="flex justify-center text-base font-semibold cursor-pointer js-changeshowallmember text-slate-600 hover:underline"
                  >
                    Views all members
                  </span>
                  {showAllMembers && (
                    <div
                      ref={nodeRefAllMember}
                      className="absolute top-[100%] left-[100%] p-4 z-50 bg-slate-200 rounded-lg"
                    >
                      {members.length > 0 ? (
                        members.map((item) => (
                          <div
                            key={v4()}
                            className="w-full flex justify-between items-center px-[10px]"
                          >
                            <input type="checkbox" />
                            <span className="text-primary">
                              {item.userName}
                            </span>
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
            ref={filterEpicRef}
            onClick={handleShowFilterEpic}
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
          </div>
          <div
            ref={filterTypeRef}
            style={
              showType ? { backgroundColor: "#4BADE8", color: "white" } : {}
            }
            onClick={handleShowFilterType}
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
          </div>
          <div
            ref={filterLabelRef}
            style={showLabel ? { backgroundColor: "#555", color: "white" } : {}}
            onClick={handleShowFilterLabel}
            className="label"
          >
            <span className={`label-number ${showLabel ? "active" : ""}`}>
              {type.length}
            </span>
            <span className="pointer-events-none title">Label</span>
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
          </div>
        </div>
      </div>
    </div>
  );
}

export default TopDetail;

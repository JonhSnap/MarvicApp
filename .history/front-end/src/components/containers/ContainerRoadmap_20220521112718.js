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
import { BASE_URL, issueTypes } from "../../util/constants";
import axios from "axios";
import AddMemberPopup from "../popup/AddMemberPopup";
import useClickOutSide from "../../hooks/useClickOutSide";
import useTooltip from "../../hooks/useTooltip";
import useHover from "../../hooks/useHover";
import WrapperTask from "../roadmap/WrapperTask";
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

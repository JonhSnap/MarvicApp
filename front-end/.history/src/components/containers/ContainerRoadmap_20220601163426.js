import React, { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import "./ContainerRoadmap.scss";
import { fetchIssue } from "../../reducers/listIssueReducer";
import { CHANGE_FILTERS_NAME } from "../../reducers/actions";
import CreateComponent from "../CreateComponent";

import useModal from "../../hooks/useModal";
import { useListIssueContext } from "../../contexts/listIssueContext";
import { v4 } from "uuid";
import { BASE_URL } from "../../util/constants";
import axios from "axios";
import useHover from "../../hooks/useHover";
import RoadmapItem from "./RoadmapItem";
import Roadmap from "../roadmap/Roadmap";
import { useMembersContext } from "../../contexts/membersContext";
import { fetchMembers } from "../../reducers/membersReducer";
import { fetchStage } from "../../reducers/stageReducer";
import { useStageContext } from "../../contexts/stageContext";
import TopDetail from "../project-detail/TopDetail";

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

  const [members, setMembers] = useState([]);
  const [focus, setFocus] = useState(false);

  const [epicSelected, setEpicSelected] = useState({
    issues: issueEpics,
    filter: [],
  });

  useEffect(() => {
    setEpicSelected((pre) => {
      return { ...pre, issues: issueEpics };
    });
  }, [issueEpics]);
  const inputRef = useRef();
  const handleFocus = () => {
    setFocus(true);
  };

  // handle change show members

  // handle close epic

  // handle close type

  // handle choose epic

  // useEffect get issues
  useEffect(() => {
    if (project && Object.entries(project).length > 0) {
      fetchIssue(project.id, dispatchIssue);
    }
  }, [project]);

  useEffect(() => {
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
    }
  }, [id, show]);

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
      <TopDetail project={project} />
      <div className="flex overflow-x-auto have-y-scroll w-full  h-[470px]">
        <div className="border-2 overflow-y-auto have-y-scroll  border-slate-200  outline-none out basis-[30%]">
          <div className=" w-full epic-dropdown have-y-scroll p-2  have-y-scroll  overflow-y-auto mx-4 bg-white rounded-[5px] flex items-center flex-col">
            <div className="flex justify-between w-full px-4 py-2 border-b-2 border-slate-200">
              <span className="text-lg font-bold text-slate-600">Epic</span>
            </div>
            {issueEpics.length > 0 &&
              issueEpics.map((item) => (
                <RoadmapItem
                  epicSelected={epicSelected}
                  setEpicSelected={setEpicSelected}
                  key={v4()}
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
          <Roadmap epicSelected={epicSelected} issueEpics={issueEpics} />
        </div>
      </div>
    </div>
  );
};

export default ContainerRoadmap;

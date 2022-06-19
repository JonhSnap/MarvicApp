import React, { useEffect, useMemo } from "react";
import TopDetail from "../project-detail/TopDetail";
import { NIL, v4 } from "uuid";
import "./ContainerBacklog.scss";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAngleDown } from "@fortawesome/free-solid-svg-icons";
import CreateComponent from "../CreateComponent";
import ButtonBacklogComponent from "../backlog/ButtonBacklogComponent";
import { useListIssueContext } from "../../contexts/listIssueContext";
import { fetchIssue } from "../../reducers/listIssueReducer";
import WrapperTask from "../backlog/WrapperTask";
import { useMembersContext } from "../../contexts/membersContext";
import WrapperSprint from "../sprint/WrapperSprint";
import { fetchStage } from "../../reducers/stageReducer";
import { fetchLabel } from "../../reducers/labelReducer";
import { useStageContext } from "../../contexts/stageContext";
import { useLabelContext } from "../../contexts/labelContext";
import { ModalProvider } from "../../contexts/modalContext";
import useLoading from "../../hooks/useLoading";
import { Skeleton } from "@mui/material";

function ContainerBacklog({ project }) {
  // xu ly loading start
  const [isLoading] = useLoading();
  // xu ly loading end
  const [{ issueNormals }, dispatchIssue] = useListIssueContext();
  const [, dispatchStage] = useStageContext();
  const [, dispatchLabel] = useLabelContext();
  const {
    state: { members },
  } = useMembersContext();

  const issueNoSprint = useMemo(() => {
    return issueNormals.filter((item) => item.id_Sprint === NIL || !item.id_Sprint);
  }, [issueNormals]);

  // useEffect get issues
  useEffect(() => {
    if (project && Object.entries(project).length > 0) {
      fetchIssue(project.id, dispatchIssue);
      fetchStage(project.id, dispatchStage);
      fetchLabel(project.id, dispatchLabel);
    }
  }, [project]);

  return (
    <ModalProvider project={project}>
      <div className="container">
        <TopDetail project={project} />
        <div className="bottom have-y-scroll">
          <div className="wrap-backlog">
            <div className="main-backlog">
              {
                isLoading ?
                  (
                    Array(3).fill(0).map(() => (
                      <div key={v4()} className="w-full shrink-0 bg-gray-main p-[30px] rounded-md overflow-hidden">
                        <div className="w-full bg-white flex flex-col justify-around p-5 gap-y-[20px]">
                          {
                            Array(3).fill(0).map(() => (
                              <div key={v4()} className="w-full h-[30px]">
                                <Skeleton style={{ backgroundColor: '#f4f5f7', borderRadius: 4 }} variant='rectangular' width='100%' height='100%' animation='wave' />
                              </div>
                            ))
                          }
                        </div>
                      </div>
                    ))
                  ) :
                  (
                    <>
                      <WrapperSprint members={members} project={project} />
                      <div data-id={NIL} className="backlog-item">
                        <div className="header-backlog-item w-[98%] py-3 flex justify-between items-center">
                          <div className="header-right">
                            <FontAwesomeIcon
                              size="1x"
                              className="inline-block px-2"
                              icon={faAngleDown}
                            />
                            <div className="inline-block name-sprint">
                              <span className="pr-2 font-medium name">Backlog</span>
                            </div>
                            <div className="inline-block pl-2 font-light create-day">
                              {/* <span className='pr-1 day'>19 Apr - 17 May</span> */}
                              <span> ({issueNoSprint.length} issues) </span>
                            </div>
                          </div>
                          <div className="flex items-center header-left h-9">
                            <div className="flex state-sprint">
                              <div className="rounded-full  inline-flex w-5 h-5 text-xs bg-[#dfe1e6] mx-[0.2rem]">
                                <span className="m-auto">4</span>
                              </div>
                              <div className="rounded-full  inline-flex w-5 h-5 text-xs bg-[#0052cc]  mx-[0.2rem] text-white">
                                <span className="m-auto">4</span>
                              </div>
                              <div className="rounded-full  inline-flex w-5 h-5 text-xs bg-[#00875a]  mx-[0.2rem] text-white">
                                <span className="m-auto">4</span>
                              </div>
                            </div>
                            {/* <div className='btn-main rounded-[5px] py-1 px-2  w-fit h-full mx-4 border-solid border-[#000] border-[1px]'>
                                    <span>Complete sprint</span>
                                </div> */}
                            <ButtonBacklogComponent
                              project={project}
                              text={"Create sprint"}
                            />
                          </div>
                        </div>
                        <div className="main w-[98%] h-fit min-h-[5rem]">
                          <WrapperTask
                            members={members}
                            project={project}
                            issues={issueNoSprint}
                          ></WrapperTask>
                          <CreateComponent project={project} createWhat={"issues"} />
                        </div>
                      </div>
                    </>
                  )
              }
            </div>
          </div>
        </div>
      </div>
    </ModalProvider>
  );
}

export default ContainerBacklog;

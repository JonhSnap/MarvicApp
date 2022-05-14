import React from "react";
import { useDispatch, useSelector } from "react-redux";

import "./ContainerRoadmap.scss";

const ContainerRoadmap = ({ project }) => {
  const { id } = project;
  const { currentUser } = useSelector((state) => state.auth.login);
  const dispatch = useDispatch();
  console.log(project);
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
      </div>
    </div>
  );
};

export default ContainerRoadmap;

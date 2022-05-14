import React from "react";

import "./ContainerRoadmap.scss";

const ContainerRoadmap = ({ project }) => {
  const { id } = project;
  return (
    <div className="container">
      <div className="top">
        <div className="navigate">
          <span>Projects</span>
          <span>/</span>
          <span>{project.name}</span>
        </div>
        <div className="wrap-key">
          <h3 className="key">{project.key} board</h3>
        </div>
      </div>
    </div>
  );
};

export default ContainerRoadmap;

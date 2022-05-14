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
      </div>
    </div>
  );
};

export default ContainerRoadmap;

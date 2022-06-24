import React, { useState } from "react";
import UserYourWork from "./UserYourWork";
import { v4 } from "uuid";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/scss";
import useHover from "../../hooks/useHover";
import avtUser from "../../images/avt-user.png";
import useClickOutSide from "../../hooks/useClickOutSide";
import { useSelector } from "react-redux";
import { KEY_CURRENT_PROJECT } from "../../util/constants";
import { useNavigate } from "react-router-dom";

const YourWorkIssue = ({ dataIssue }) => {
  const navigate = useNavigate();
  const isType2 = dataIssue.id_IssueType === 2;
  const isType3 = dataIssue.id_IssueType === 3;
  const isType4 = dataIssue.id_IssueType === 4;
  const isType1 = dataIssue.id_IssueType === 1;
  const [hoverRef, isHovered] = useHover();
  const [hoverRef1, isHovered1] = useHover();
  const { show, setShow, nodeRef } = useClickOutSide();

  const projects = useSelector((state) => state.projects.projects);
  const keyProject = projects.find(
    (project) => project.id === dataIssue.id_Project
  );

  const handleClickName = (key) => {
    localStorage.setItem(KEY_CURRENT_PROJECT, key);
    navigate(`/projects/board/${key}`);
  };

  console.log("dataIssue", dataIssue);
  return (
    <div className="flex items-center w-full p-1 rounded-lg cursor-pointer hover:bg-slate-200">
      <div>
        {isType2 && (
          <img
            src="http://localhost:3000/static/media/story.29b1ddadbd9c9361c80f.jpg"
            alt=""
            className="w-6"
          />
        )}
        {isType3 && (
          <img
            src="http://localhost:3000/static/media/task.b8da2cdd2f57bbd0748a.jpg"
            alt=""
            className="w-6"
          />
        )}
        {isType4 ||
          (isType1 && (
            <img
              src="http://localhost:3000/static/media/bug.28f77bb8e0d6412801e5.jpg"
              alt=""
              className="w-6"
            />
          ))}
      </div>
      <div className="flex items-center justify-between w-full ml-4">
        <div onClick={() => handleClickName(keyProject.key)} className="">
          <h4 className="text-xl font-semibold">{dataIssue.summary}</h4>
          <span className="text-base font-normal text-slate-600">
            {dataIssue.projectName}
          </span>
        </div>
        <div className="w-[450px] flex items-center justify-between pr-20">
          <span className="flex items-center text-base font-normal text-slate-500">
            {dataIssue.status}
          </span>
          <div className="flex justify-between "></div>
        </div>
      </div>
    </div>
  );
};

export default YourWorkIssue;

import React from "react";
import UserYourWork from "./UserYourWork";
import { v4 } from "uuid";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/scss";
import useHover from "../../hooks/useHover";
import avtUser from "../../images/avt-user.png";

const YourWorkIssue = ({ dataIssue }) => {
  const isType2 = dataIssue.id_IssueType === 2;
  const isType3 = dataIssue.id_IssueType === 3;
  const isType4 = dataIssue.id_IssueType === 4;
  const isType1 = dataIssue.id_IssueType === 1;
  const [hoverRef, isHovered] = useHover();
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
        <div className="">
          <h4 className="text-xl font-semibold">{dataIssue.summary}</h4>
          <span className="text-base font-normal text-slate-600">
            {dataIssue.projectName}
          </span>
        </div>
        <span className="flex items-center text-base font-normal text-slate-500">
          {dataIssue.status}
        </span>
        <div className=" flex justify-between">
          <div className="flex w-[235px]">
            <>
              <div className=" w-[40px] [h-40px] relative ">
                {isHovered ? (
                  <span className="w-auto absolute z-10  bg-black text-white text-sm px-2 py-1  l-0 rounded-lg top-[100%]">
                    {dataIssue.users[0].userName}
                  </span>
                ) : (
                  ""
                )}

                <img
                  ref={hoverRef}
                  src={avtUser}
                  alt=""
                  className="w-[40px] h-[40px] border-2 border-white rounded-full"
                />
              </div>
              {dataIssue.users.map((user) => (
                <UserYourWork key={v4()} user={user}></UserYourWork>
              ))}
            </>
          </div>
        </div>
      </div>
    </div>
  );
};

export default YourWorkIssue;

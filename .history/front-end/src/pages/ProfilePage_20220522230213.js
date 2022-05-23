import React, { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
const ProfilePage = () => {
  const [avt, setAvt] = useState(
    "https://trello-members.s3.amazonaws.com/624e70dfe1032520d20044f1/8685ee9f75d8ac6ea68287652c33041f/170.png"
  );
  useEffect(() => {
    document.title = "Lý lịch | Marvic";
  }, []);
  const user = useSelector((state) => state.auth.login.currentUser);
  console.log(user);
  return (
    <div className="w-full">
      <div className="text-center w-full  h-[192px] bg-[#f4f5f7] ">
        <div className="w-[1320px] mx-auto flex justify-center  pt-10 select-none">
          <div className="items-center w-12">
            <img src={avt} alt="avt-user" className="w" />
          </div>
          <h3 className="ml-4 text-2xl text-[#0c3953] items-center">
            {user.userName}
          </h3>
          <span className="ml-3 text-sm text-slate-500">@{user.userName}</span>
        </div>
        <div className="inline-block p-5 bg-white rounded-lg mt-[53px] ">
          <h2 className="text-3xl text-[#0c3953]">Hồ sơ và hiển thị</h2>
        </div>
      </div>
      <div className="w-[600px] mx-auto mt-10">
        <div className="flex flex-col justify-center">
          <h2 className="text-base text-[#172b4d] ">
            Quản lý thông tin cá nhân của bạn, đồng thời kiểm soát thông tin nào
            người khác xem được và ứng dụng nào có thể truy cập.
          </h2>
          <span className="text-base text-[#0065ff]  mt-8 cursor-pointer">
            Tìm hiểu thêm về hồ sơ và chế độ hiển thị của bạn{" "}
            <span className="text-[#172b4d]">hoặc</span> xem chính sách quyền
            riêng tư của chúng tôi.
          </span>
        </div>
        <div className="w-full mt-4">
          <h3>Ảnh hồ sơ và ảnh tiêu đề</h3>
          <div className="w-full h-[212px] bg-[#a4f0fc] rounded-lg">
            <div>
              {" "}
              <div className="items-center w-12">
                <img src={avt} alt="avt-user" className="w" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProfilePage;

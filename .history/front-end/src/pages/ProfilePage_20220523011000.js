import React, { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import ProfileDetails from "../components/profile-details/ProfileDetails";
import { BASE_URL } from "../util/constants";
import axios from "axios";
const ProfilePage = () => {
  const user = useSelector((state) => state.auth.login.currentUser);
  const [avt, setAvt] = useState(
    "https://trello-members.s3.amazonaws.com/624e70dfe1032520d20044f1/8685ee9f75d8ac6ea68287652c33041f/170.png"
  );
  const imageHandler = (e) => {
    const reader = new FileReader();
    reader.onload = () => {
      if (reader.readyState === 2) {
        setAvt(reader.result);
      }
    };
    reader.readAsDataURL(e.target.files[0]);
  };
  useEffect(() => {
    document.title = "Lý lịch | Marvic";
  }, []);
  const updateUser = async (text, idUser) => {
    await axios
      .put(`${BASE_URL}/api/User/Update`, {
        id: idUser,
        fullName: text,
      })
      .then(() => {
        console.log("success");
      });
  };

  return (
    <div className="w-full pb-20">
      <div className="text-center w-full  h-[192px] bg-[#f4f5f7] ">
        <div className="w-[1320px] mx-auto flex justify-center  pt-10 select-none">
          <div className="items-center">
            <img src={avt} alt="avt-user" className="w img-avt" />
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
      <div className="w-[600px] mx-auto mt-[40px]">
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
          <h3 className="text-xl font-semibold text-slate-600">
            Ảnh hồ sơ và ảnh tiêu đề
          </h3>
          <div className="w-full h-[212px] bg-[#a4f0fc] rounded-lg  border-slate-500 border-2">
            <div className="h-[100px] bg-white p-10 flex ">
              <div className="items-center w-[105px]">
                <img src={avt} alt="avt-user" className="img-avt" />
              </div>
              <div className="ml-10 ">
                <h3 className="text-xl font-semibold text-blue-500">
                  {user.fullName}
                </h3>
                <span className="text-sm text-slate-600">{user.email}</span>
              </div>
            </div>
            <div className="mt-10 ml-5">
              <input
                type="file"
                name="image-upload"
                id="input-avt"
                accept="image/*"
                className="cursor-pointer "
                onChange={imageHandler}
              />
              <div className="inline-block p-2 mt-2 text-white cursor-pointer bg-slate-500 label-avt rounded-2xl">
                <label
                  htmlFor="input-avt"
                  className="flex items-center cursor-pointer image-upload"
                >
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    class="h-6 w-6"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke="currentColor"
                    stroke-width="2"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      d="M4 16l4.586-4.586a2 2 0 012.828 0L16 16m-2-2l1.586-1.586a2 2 0 012.828 0L20 14m-6-6h.01M6 20h12a2 2 0 002-2V6a2 2 0 00-2-2H6a2 2 0 00-2 2v12a2 2 0 002 2z"
                    />
                  </svg>
                  Thay đổi ảnh đại diện
                </label>
              </div>
            </div>
          </div>
        </div>
        <div className="mt-10">
          <h3 className="text-xl font-semibold text-slate-600">
            Giới thiệu về bạn
          </h3>
          <div className="p-5 pb-10 border-2 rounded-lg border-slate-600">
            <ProfileDetails
              handleSubmit={(text) => updateUser(text)}
              updateUser={updateUser}
              label={"Full name"}
              value={user.fullName}
            ></ProfileDetails>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProfilePage;

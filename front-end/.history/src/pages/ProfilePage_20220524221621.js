import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import ProfileDetails from "../components/profile-details/ProfileDetails";
import avtUser from "../images/avt-user.png";
import { BASE_URL } from "../util/constants";
import axios from "axios";
import createToast from "../util/createToast";
const ProfilePage = () => {
  const user = useSelector((state) => state.auth.login.currentUser);
  const [dataUser, setDataUser] = useState([]);
  const [avt, setAvt] = useState(user.avatar || avtUser);
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
    const getUserDetails = async () => {
      const resp = await axios.get(
        "https://localhost:5001/api/User/GetLoginUser"
      );
      if (resp && resp.status === 200) {
        setDataUser(resp.data);
      } else {
        throw new Error("Error when fetch user details");
      }
    };
    getUserDetails();
  }, []);

  useEffect(() => {
    const updateUserAvt = async (urlAvt) => {
      const updateAvatar = {
        id: user.id,
        fullName: user.fullName,
        userName: user.userName,
        avatar: urlAvt,
        email: user.email,
        organization: user.organization,
        phoneNumber: user.phoneNumber,
      };
      await axios
        .put(`${BASE_URL}/api/User/Update`, updateAvatar)
        .then((data) => {
          // console.log(data);
        });
    };
    updateUserAvt(avt);
    console.log("avt", avt);
  }, [avt]);

  const updateUserFullName = async (text) => {
    const updateFullName = {
      id: user.id,
      fullName: text,
      userName: user.userName,
      avatar: avt,
      email: user.email,
      jobTitle: user.jobTitle,
      organization: user.organization,
      phoneNumber: user.phoneNumber,
    };
    await axios
      .put(`${BASE_URL}/api/User/Update`, updateFullName)
      .then((data) => {
        console.log("update fullname success");
      });
  };
  const updateUserUserName = async (text) => {
    const updateUserName = {
      id: user.id,
      fullName: user.fullName,
      userName: text,
      avatar: avt,
      email: user.email,
      jobTitle: user.jobTitle,
      organization: user.organization,
      phoneNumber: user.phoneNumber,
    };
    await axios
      .put(`${BASE_URL}/api/User/Update`, updateUserName)
      .then((data) => {
        console.log("update fullname success");
      });
  };
  useEffect(() => {
    document.title = "Lý lịch | Marvic";
  }, []);
  console.log(user);
  const handleSubmitDelete = (event) => {
    event.preventDefault();
    setAvt("");
    createToast("success", "Delete avatar successfully!");
  };
  return (
    <div className="w-full pb-20">
      <div className="text-center w-full  h-[192px] header-avt-top ">
        <div className="w-[1320px] mx-auto flex justify-center  pt-10 select-none">
          <div className="items-center">
            <img src={avt} alt="avt-user" className="w img-avt" />
          </div>
          <div className="flex">
            <h3 className="ml-4 text-2xl text-[#0c3953] items-center">
              {user.userName}
            </h3>
            <span className=" text-sm text-slate-500 mt-[15px]">
              @{user.userName}
            </span>
          </div>
        </div>
        <div className="inline-block p-5 bg-white rounded-lg ml-[400px] ">
          <h2 className="text-3xl text-[#0c3953]">Hồ sơ và chế độ hiển thị</h2>
        </div>
      </div>
      <div className="w-[1320px] flex mx-auto">
        <div className="basis-[30%] h-[100vh] header-avt-top mt-[40px] rounded-lg p-5 flex  flex-col  ">
          <div className="flex items-center justify-center ">
            <svg
              height="50"
              width="50"
              fill="none"
              viewBox="0 0 185 180"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                d="M58.086 39.6001H55.2226C52.3106 39.6001 49.95 41.8969 49.95 44.7302V113.132C49.95 115.965 52.3106 118.262 55.2226 118.262H58.086C60.998 118.262 63.3586 115.965 63.3586 113.132V44.7302C63.3586 41.8969 60.998 39.6001 58.086 39.6001Z"
                fill="#34568B"
              ></path>
              <path
                d="M82.0301 51.4417H79.1667C76.2547 51.4417 73.894 53.7385 73.894 56.5718V113.132C73.894 115.965 76.2547 118.262 79.1667 118.262H82.0301C84.9421 118.262 87.3027 115.965 87.3027 113.132V56.5718C87.3027 53.7385 84.9421 51.4417 82.0301 51.4417Z"
                fill="#8777D9"
              ></path>
              <path
                d="M105.974 64.1289H103.111C100.199 64.1289 97.838 66.4257 97.838 69.259V113.132C97.838 115.965 100.199 118.262 103.111 118.262H105.974C108.886 118.262 111.247 115.965 111.247 113.132V69.259C111.247 66.4257 108.886 64.1289 105.974 64.1289Z"
                fill="#63BA3C"
              ></path>
              <path
                d="M129.918 80.1997H127.055C124.143 80.1997 121.782 82.4965 121.782 85.3298V113.132C121.782 115.965 124.143 118.262 127.055 118.262H129.918C132.83 118.262 135.191 115.965 135.191 113.132V85.3298C135.191 82.4965 132.83 80.1997 129.918 80.1997Z"
                fill="#4BADE8"
              ></path>
              <path
                d="M69.0013 122.886V140.4H66.0487V128.405L60.5579 140.4H58.5118L52.9951 128.405V140.4H50.0425V122.886H53.2282L59.5478 136.62L65.8415 122.886H69.0013ZM71.8978 133.394C71.8978 132 72.1914 130.765 72.7784 129.69C73.3828 128.615 74.1942 127.783 75.213 127.195C76.249 126.59 77.3886 126.288 78.6318 126.288C79.7542 126.288 80.7297 126.506 81.5585 126.943C82.4045 127.363 83.0779 127.892 83.5787 128.531V126.515H86.5572V140.4H83.5787V138.334C83.0779 138.989 82.396 139.535 81.5326 139.972C80.6692 140.409 79.685 140.627 78.58 140.627C77.354 140.627 76.2318 140.324 75.213 139.72C74.1942 139.098 73.3828 138.241 72.7784 137.149C72.1914 136.04 71.8978 134.789 71.8978 133.394ZM83.5787 133.445C83.5787 132.487 83.3715 131.656 82.9571 130.95C82.5599 130.244 82.0334 129.707 81.3772 129.337C80.721 128.968 80.0132 128.783 79.2534 128.783C78.4936 128.783 77.7858 128.968 77.1296 129.337C76.4734 129.69 75.9382 130.219 75.5238 130.925C75.1266 131.614 74.9281 132.437 74.9281 133.394C74.9281 134.352 75.1266 135.192 75.5238 135.914C75.9382 136.637 76.4734 137.191 77.1296 137.578C77.803 137.947 78.511 138.132 79.2534 138.132C80.0132 138.132 80.721 137.947 81.3772 137.578C82.0334 137.208 82.5599 136.67 82.9571 135.965C83.3715 135.243 83.5787 134.402 83.5787 133.445ZM93.388 128.531C93.8196 127.825 94.3894 127.279 95.0974 126.893C95.8226 126.49 96.6773 126.288 97.6615 126.288V129.262H96.9104C95.7536 129.262 94.873 129.547 94.2686 130.118C93.6816 130.69 93.388 131.681 93.388 133.092V140.4H90.4354V126.515H93.388V128.531ZM105.892 137.83L109.933 126.515H113.066L107.627 140.4H104.105L98.6919 126.515H101.852L105.892 137.83ZM116.8 124.675C116.265 124.675 115.816 124.499 115.454 124.146C115.091 123.793 114.91 123.356 114.91 122.836C114.91 122.315 115.091 121.878 115.454 121.525C115.816 121.172 116.265 120.996 116.8 120.996C117.318 120.996 117.759 121.172 118.121 121.525C118.484 121.878 118.665 122.315 118.665 122.836C118.665 123.356 118.484 123.793 118.121 124.146C117.759 124.499 117.318 124.675 116.8 124.675ZM118.251 126.515V140.4H115.298V126.515H118.251ZM121.143 133.445C121.143 132.017 121.437 130.765 122.024 129.69C122.628 128.598 123.457 127.758 124.51 127.17C125.564 126.582 126.772 126.288 128.136 126.288C129.863 126.288 131.287 126.691 132.41 127.498C133.549 128.287 134.318 129.421 134.715 130.9H131.529C131.27 130.211 130.856 129.673 130.286 129.287C129.716 128.9 129 128.707 128.136 128.707C126.928 128.707 125.961 129.127 125.235 129.967C124.528 130.79 124.173 131.95 124.173 133.445C124.173 134.94 124.528 136.108 125.235 136.948C125.961 137.788 126.928 138.208 128.136 138.208C129.846 138.208 130.977 137.477 131.529 136.015H134.715C134.3 137.426 133.523 138.552 132.384 139.392C131.244 140.215 129.828 140.627 128.136 140.627C126.772 140.627 125.564 140.333 124.51 139.745C123.457 139.14 122.628 138.3 122.024 137.225C121.437 136.133 121.143 134.873 121.143 133.445Z"
                fill="url(#paint0_linear_66_861)"
              ></path>
              <path
                d="M92.5 171C138.478 171 175.75 134.735 175.75 90C175.75 45.2649 138.478 9 92.5 9C46.5223 9 9.25 45.2649 9.25 90C9.25 134.735 46.5223 171 92.5 171Z"
                stroke="url(#paint1_linear_66_861)"
                strokeWidth="10"
              ></path>
              <defs>
                <linearGradient
                  id="paint0_linear_66_861"
                  gradientUnits="userSpaceOnUse"
                  x1="92.3786"
                  x2="92.3786"
                  y1="120.996"
                  y2="140.627"
                >
                  <stop stopColor="#344C8B"></stop>
                  <stop offset="1" stopColor="#8777D9"></stop>
                </linearGradient>
                <linearGradient
                  id="paint1_linear_66_861"
                  gradientUnits="userSpaceOnUse"
                  x1="92.5"
                  x2="92.5"
                  y1="8.1"
                  y2="180"
                >
                  <stop stopColor="#34568B"></stop>
                  <stop offset="0.980533" stopColor="#8777D9"></stop>
                </linearGradient>
              </defs>
            </svg>
            <h1 className="text-3xl font-semibold text-slate-500 ml-7">
              Tài Khoản Marvic
            </h1>
          </div>
          <div className="flex flex-col mt-10 ml-[100px]">
            <div className="p-4 mb-3 text-blue-600 rounded-lg cursor-pointer bg-slate-200 hover:bg-slate-300">
              <h3 className="text-xl ">Hồ sơ và chế độ hiển thị</h3>
            </div>
            <div className="p-4 mb-3 rounded-lg cursor-pointer hover:bg-slate-300">
              <h3 className="text-xl ">Email</h3>
            </div>
            <div className="p-4 mb-3 rounded-lg cursor-pointer hover:bg-slate-300">
              <h3 className="text-xl ">Bảo mật</h3>
            </div>
          </div>
        </div>
        <div className="basis-[70%] ml-10 mx-auto mt-[40px] float-right">
          <div className="flex flex-col justify-center">
            <h2 className="text-base text-[#172b4d] ">
              Quản lý thông tin cá nhân của bạn, đồng thời kiểm soát thông tin
              nào người khác xem được và ứng dụng nào có thể truy cập.
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
            <div className="w-full h-[230px]  rounded-lg header-avt  border-slate-500 border-2">
              <div className="h-[110px] header-avt-top  p-10 flex ">
                <div className="items-center w-[105px] mt-5">
                  <img src={avt} alt="avt-user" className="img-avt" />
                </div>
                <div className="mt-8 ml-10 ">
                  <h3 className="text-2xl font-semibold text-blue-500">
                    {user.fullName}
                  </h3>
                  <span className="text-base text-slate-600">{user.email}</span>
                </div>
              </div>
              <form onSubmit={handleSubmitDelete}>
                <div className="mt-10 ml-5">
                  <input
                    type="file"
                    name="image-upload"
                    id="input-avt"
                    accept="image/*"
                    className="cursor-pointer "
                    onChange={imageHandler}
                  />
                  <div className="inline-block p-2 mt-2 text-white transition-all cursor-pointer hover:bg-slate-400 hover: bg-slate-500 label-avt rounded-2xl">
                    <label
                      htmlFor="input-avt"
                      className="flex items-center cursor-pointer image-upload"
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        className="w-6 h-6"
                        fill="none"
                        viewBox="0 0 24 24"
                        stroke="currentColor"
                        strokeWidth="2"
                      >
                        <path
                          strokeLinecap="round"
                          strokeLinejoin="round"
                          d="M4 16l4.586-4.586a2 2 0 012.828 0L16 16m-2-2l1.586-1.586a2 2 0 012.828 0L20 14m-6-6h.01M6 20h12a2 2 0 002-2V6a2 2 0 00-2-2H6a2 2 0 00-2 2v12a2 2 0 002 2z"
                        />
                      </svg>
                      Thay đổi ảnh đại diện
                    </label>
                  </div>
                  <div className="flex justify-end ">
                    {user.avatar && (
                      <button
                        type="submit"
                        className="px-2 py-3 mr-4 text-base text-white bg-red-400 rounded-lg hover:bg-red-600"
                      >
                        Xóa ảnh đại diện
                      </button>
                    )}
                  </div>
                </div>
              </form>
            </div>
          </div>
          <div className="mt-10">
            <h3 className="text-xl font-semibold text-slate-600">
              Giới thiệu về bạn
            </h3>
            <div className="p-5 pb-10 border-2 rounded-lg border-slate-600">
              <ProfileDetails
                handleSubmit={(text) => updateUserFullName(text, user.id)}
                label={"Full name"}
                valueFullName={user.fullName}
              ></ProfileDetails>
              <ProfileDetails
                handleSubmit={(text) => updateUserUserName(text, user.id)}
                label={"User name"}
                valueFullName={user.userName}
              ></ProfileDetails>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProfilePage;

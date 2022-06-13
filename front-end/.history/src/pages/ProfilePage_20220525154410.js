import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import ProfileDetails from "../components/profile-details/ProfileDetails";
import avtUser from "../images/avt-user.png";
import { BASE_URL } from "../util/constants";
import axios from "axios";
import ProfilePrimary from "../components/profile-details/ProfilePrimary";
const ProfilePage = () => {
  const [user, setUser] = useState([]);
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

  // const addAvt = async (avatar) => {
  //   await axios
  //     .post(`${BASE_URL}/api/User/UploadAvatar`, {
  //       avatar,
  //       id,
  //     })
  //     .then((cmt) => {
  //       console.log(cmt);
  //       getUserDetails();
  //     });
  // };
  const handleSubmitAvt = async (event) => {
    event.preventDefault();
    const formData = new FormData();
    formData.append("avt", avt);
    console.log(formData);
    await axios
      .post(`${BASE_URL}/api/User/UploadAvatar`, formData)
      .then((res) => {
        console.log(res);
        getUserDetails();
      });
  };

  const getUserDetails = async () => {
    const resp = await axios.get(`${BASE_URL}/api/User/GetLoginUser`);
    if (resp && resp.status === 200) {
      setUser(resp.data);
    } else {
      throw new Error("Error when fetch user details");
    }
  };
  useEffect(() => {
    document.title = "Lý lịch | Marvic";
    getUserDetails();
  }, []);

  const updateUserFullName = async (text) => {
    const updateFullName = {
      id: user.id,
      fullName: text,
      userName: user.userName,
      email: user.email,
      jobTitle: user.jobTitle,
      organization: user.organization,
      phoneNumber: user.phoneNumber,
    };
    await axios
      .put(`${BASE_URL}/api/User/Update`, updateFullName)
      .then((data) => {
        console.log("update fullname success");
        getUserDetails();
      });
  };
  const updateUserUserName = async (text) => {
    const updateUserName = {
      id: user.id,
      fullName: user.fullName,
      userName: text,
      email: user.email,
      jobTitle: user.jobTitle,
      organization: user.organization,
      phoneNumber: user.phoneNumber,
    };
    await axios
      .put(`${BASE_URL}/api/User/Update`, updateUserName)
      .then((data) => {
        console.log("update fullname success");
        getUserDetails();
      });
  };
  const updateUserUserEmail = async (text) => {
    const updateUserName = {
      id: user.id,
      fullName: user.fullName,
      userName: user.userName,
      avatar: avt,
      email: text,
      jobTitle: user.jobTitle,
      organization: user.organization,
      phoneNumber: user.phoneNumber,
    };
    await axios
      .put(`${BASE_URL}/api/User/Update`, updateUserName)
      .then((data) => {
        console.log("update fullname success");
        getUserDetails();
      });
  };
  const updateUserUserJobTitle = async (text) => {
    const updateUserName = {
      id: user.id,
      fullName: user.fullName,
      userName: user.userName,
      email: user.email,
      jobTitle: text,
      organization: user.organization,
      phoneNumber: user.phoneNumber,
    };
    await axios
      .put(`${BASE_URL}/api/User/Update`, updateUserName)
      .then((data) => {
        console.log("update fullname success");
        getUserDetails();
      });
  };
  const updateUserUserDepartment = async (text) => {
    const updateUserName = {
      id: user.id,
      fullName: user.fullName,
      userName: user.userName,
      email: user.email,
      jobTitle: user.jobTitle,
      department: text,
      organization: user.organization,
      phoneNumber: user.phoneNumber,
    };
    await axios
      .put(`${BASE_URL}/api/User/Update`, updateUserName)
      .then((data) => {
        console.log("update fullname success");
        getUserDetails();
      });
  };
  const updateUserUserOrganization = async (text) => {
    const updateUserName = {
      id: user.id,
      fullName: user.fullName,
      userName: user.userName,
      email: user.email,
      jobTitle: user.jobTitle,
      department: user.department,
      organization: text,
      phoneNumber: user.phoneNumber,
    };
    await axios
      .put(`${BASE_URL}/api/User/Update`, updateUserName)
      .then((data) => {
        console.log("update fullname success");
        getUserDetails();
      });
  };
  const updateUserUserPhoneNumber = async (text) => {
    const updateUserName = {
      id: user.id,
      fullName: user.fullName,
      userName: user.userName,
      email: user.email,
      jobTitle: user.jobTitle,
      department: user.department,
      organization: user.organization,
      phoneNumber: text,
    };
    await axios
      .put(`${BASE_URL}/api/User/Update`, updateUserName)
      .then((data) => {
        console.log("update fullname success");
        getUserDetails();
      });
  };

  return <>{user ? <ProfilePrimary></ProfilePrimary> : null}</>;
};

export default ProfilePage;

import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";

import avtUser from "../images/avt-user.png";
import { BASE_URL } from "../util/constants";
import axios from "axios";
import ProfilePrimary from "../components/profile-details/ProfilePrimary";
const ProfilePage = () => {
  const [user, setUser] = useState([]);

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

  return (
    <>
      {user ? (
        <ProfilePrimary
          getUserDetails={getUserDetails}
          user={user}
          updateUserUserEmail={updateUserUserEmail}
          updateUserUserPhoneNumber={updateUserUserPhoneNumber}
          updateUserUserOrganization={updateUserUserOrganization}
          updateUserUserJobTitle={updateUserUserJobTitle}
          updateUserUserDepartment={updateUserUserDepartment}
          updateUserUserName={updateUserUserName}
          updateUserFullName={updateUserFullName}
        ></ProfilePrimary>
      ) : null}
    </>
  );
};

export default ProfilePage;

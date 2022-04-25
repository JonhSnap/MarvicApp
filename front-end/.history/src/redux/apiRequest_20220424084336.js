import axios from "axios";
import { BASE_URL } from "../util/constants";
import {
  getProjectsStart,
  getProjectsError,
  getProjectsSuccess,
} from "./projectsSlice";
import {
  loginFailed,
  loginStart,
  loginSuccess,
  logOutFailed,
  logOutStart,
  logOutSuccess,
  registerFailed,
  registerStart,
  registerSuccess,
} from "./authSlice";

export const loginUser = async (user, dispatch, navigate) => {
  dispatch(loginStart);
  try {
    const res = await axios.post("https://localhost:5001/api/User/login", user);
    dispatch(loginSuccess(res.data));
    alert("login Success");
    navigate("/");
    console.log("====================================");
    console.log("User login", res);
    console.log("====================================");
  } catch (err) {
    dispatch(loginFailed());
  }
};

export const registerUser = async (user, dispatch, navigate) => {
  dispatch(registerStart);
  try {
    await axios.post("https://localhost:5001/api/User/register", user);
    dispatch(registerSuccess());
    navigate("/login");
  } catch (error) {
    dispatch(registerFailed());
  }
};

export const logOut = async (dispatch, navigate, id) => {
  dispatch(logOutStart);
  try {
    await axios.post("https://localhost:5001/api/User/logout");
    dispatch(logOutSuccess());
    navigate("/login");
  } catch (error) {
    dispatch(logOutFailed);
  }
};

export const getProjects = async (dispatch) => {
  dispatch(getProjectsStart);
  try {
    const resp = await axios.get(`${BASE_URL}/api/Project/GetAlls`);
    if (resp && resp.data.length > 0) {
      dispatch(getProjectsSuccess(resp.data));
    }
  } catch (err) {
    dispatch(getProjectsError());
  }
};

import axios from "axios";
import {
  loginFailed,
  loginStart,
  loginSuccess,
  registerFailed,
  registerStart,
  registerSuccess,
} from "./authSlice";

export const loginUser = async (user, dispatch, navigate) => {
  dispatch(loginStart);
  try {
    const res = await axios.post("https://localhost:5001/api/User/login", user);
    dispatch(loginSuccess(res.data));
    navigate("/");
  } catch (err) {
    dispatch(loginFailed());
    alert("Ten dang nhap hoac mat khau khong chinh xac");
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

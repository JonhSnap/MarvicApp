import React, { useState, useEffect } from "react";
import axios from "axios";
import { BASE_URL } from "../util/constants";
function YourWorkPage() {
  const [dataYourWork, setDataYourWork] = useState([]);

  const getUserDetails = async () => {
    const resp = await axios.get(`${BASE_URL}/api/WorkedOn`);
    if (resp && resp.status === 200) {
      setDataYourWork(resp.data);
    } else {
      throw new Error("Error when fetch user details");
    }
  };
  useEffect(() => {
    document.title = "Your work";
    getUserDetails();
  }, []);
  return <div></div>;
}

export default YourWorkPage;

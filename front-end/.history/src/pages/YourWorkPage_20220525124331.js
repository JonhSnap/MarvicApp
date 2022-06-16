import React, { useState, useEffect } from "react";
import axios from "axios";
import { BASE_URL } from "../util/constants";
function YourWorkPage() {
  const [dataYourWork, setDataYourWork] = useState([]);

  const getYourWork = async () => {
    const resp = await axios.get(`${BASE_URL}/api/WorkedOn`);
    if (resp && resp.status === 200) {
      setDataYourWork(resp.data);
    } else {
      throw new Error("Error when fetch get YourWork ");
    }
  };
  useEffect(() => {
    document.title = "Your work";
    getYourWork();
  }, []);
  console.log("====================================");
  console.log(dataYourWork.items);
  console.log("====================================");
  return <div></div>;
}

export default YourWorkPage;

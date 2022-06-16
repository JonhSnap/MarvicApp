import axios from "axios";
import React, { useEffect, useState } from "react";
import { BASE_URL } from "../util/constants";

const TestListPage = () => {
  const [getTest, setGetTest] = useState();
  const getTestList = async () => {
    await axios
      .get(`${BASE_URL}/api/TestResults/GetTests`)
      .then((res) => {
        setGetTest(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };
  useEffect(() => {
    document.title = "Test-result";
    getTestList();
  }, []);

  console.log(getTest);
  return <div className="w-[1320px] mx-auto p-4">List-Page</div>;
};

export default TestListPage;

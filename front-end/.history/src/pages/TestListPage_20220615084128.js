import React, { useEffect, useState } from "react";
import { BASE_URL } from "../util/constants";
import axios from "axios";
import TestItem from "../components/test-list/TestItem";

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
  return (
    <div className="w-[1320px] mx-auto p-4">
      {getTest &&
        getTest.length > 0 &&
        getTest.map((item) => <TestItem TestItem={item}></TestItem>)}
    </div>
  );
};

export default TestListPage;

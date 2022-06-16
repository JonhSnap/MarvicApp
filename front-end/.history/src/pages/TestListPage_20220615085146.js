import React, { useEffect, useState } from "react";
import { BASE_URL } from "../util/constants";
import axios from "axios";
import TestItem from "../components/test-list/TestItem";
import { v4 } from "uuid";
import "../components/test-list/TestItem.scss";

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
      <h2 className="font-semibold text-4xl">List of tests</h2>
      <div className="">
        {getTest && getTest.length > 0 ? (
          getTest.map((item) => (
            <TestItem key={v4()} TestItem={item}></TestItem>
          ))
        ) : (
          <div>you don't have any test</div>
        )}
      </div>
    </div>
  );
};

export default TestListPage;

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
      <h2 className="heading-test font-semibold">
        List of tests ({getTest?.length})
      </h2>
      <div className="flex flex-wrap gap-10 mt-8 border-2 shadow-md">
        {/* {getTest && getTest.length > 0 ? (
          getTest.map((item) => (
            <TestItem key={v4()} TestItem={item}></TestItem>
          ))
        ) : ( */}
        <div>you don't have any test</div>
        {/* )} */}
      </div>
    </div>
  );
};

export default TestListPage;

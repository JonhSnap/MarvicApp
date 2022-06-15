import React from "react";
import { useNavigate } from "react-router-dom";

const TestItem = ({ TestItem }) => {
  const navigate = useNavigate();
  console.log("TestItem", TestItem);
  return (
    <div className="w-[27%] py-8 px-4 flex justify-center btn ">
      <h2>{TestItem.name}</h2>
    </div>
  );
};

export default TestItem;
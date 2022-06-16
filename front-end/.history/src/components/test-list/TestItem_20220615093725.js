import React from "react";
import { useNavigate } from "react-router-dom";

const TestItem = ({ TestItem }) => {
  const navigate = useNavigate();
  console.log("TestItem", TestItem);
  const handleNavigate = () => {
    navigate(`/test/${TestItem.id}/${TestItem.name}`);
  };
  return (
    <div
      onClick={handleNavigate}
      className="w-[27%] py-8 px-4 flex justify-center button type1"
    >
      <h2>{TestItem.name}</h2>
    </div>
  );
};

export default TestItem;

import React, { useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import axios from "axios";

const BarChartColumn = () => {
  const [dataColumn, setDataColumn] = useState([]);
  const options = {
    title: {
      text: "Basic Column Chart",
    },
    data: [
      {
        // Change type to "doughnut", "line", "splineArea", etc.
        type: "column",
        dataPoints: [
          { label: "Apple", y: 10 },
          { label: "Orange", y: 15 },
          { label: "Banana", y: 25 },
          { label: "Mango", y: 30 },
          { label: "Grape", y: 28 },
        ],
      },
    ],
  };
  return (
    <div className="mt-[30px]">
      <h2 className="text-2xl font-bold text-blue-600">
        Chart column Year month day
      </h2>
      <CanvasJSChart options={options} />
    </div>
  );
};

export default BarChartColumn;

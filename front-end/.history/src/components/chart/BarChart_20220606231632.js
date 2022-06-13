import React from "react";
import { CanvasJSChart } from "canvasjs-react-charts";

const BarChart = () => {
  const options = {
    theme: "light2",
    animationEnabled: true,
    exportEnabled: true,
    title: {
      text: "Number of iPhones Sold",
    },
    axisY: {
      title: "Number of iPhones ( in Million )",
    },
    data: [
      {
        type: "area",
        xValueFormatString: "YYYY",
        yValueFormatString: "#,##0.## Million",
        dataPoints: [
          { x: new Date(2017, 0), y: 7.6 },
          { x: new Date(2016, 0), y: 7.3 },
          { x: new Date(2015, 0), y: 6.4 },
          { x: new Date(2014, 0), y: 5.3 },
          { x: new Date(2013, 0), y: 4.5 },
          { x: new Date(2012, 0), y: 3.8 },
          { x: new Date(2011, 0), y: 3.2 },
        ],
      },
    ],
  };

  const optionsColumn = {
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
    <div className="p-5">
      <div className="mt-">
        <h2 className="text-2xl  flex justify-between w-full">
          Chart area Year
        </h2>
        <CanvasJSChart options={options} />
      </div>
      <div>
        <CanvasJSChart options={optionsColumn} />
      </div>
    </div>
  );
};

export default BarChart;

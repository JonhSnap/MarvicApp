import React from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import axios from "axios";

const BarChartDoughnut = () => {
  const options = {
    animationEnabled: true,
    title: {
      text: "Customer Satisfaction",
    },
    subtitles: [
      {
        text: "71% Positive",
        verticalAlign: "center",
        fontSize: 24,
        dockInsidePlotArea: true,
      },
    ],
    data: [
      {
        type: "doughnut",
        showInLegend: true,
        indexLabel: "{name}: {y}",
        yValueFormatString: "#,###'%'",
        dataPoints: [
          { name: "Unsatisfied", y: 5 },
          { name: "Very Unsatisfied", y: 31 },
          { name: "Very Satisfied", y: 40 },
          { name: "Satisfied", y: 17 },
          { name: "Neutral", y: 7 },
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

export default BarChartDoughnut;

import React, { useEffect, useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import axios from "axios";
const BarChartArea = () => {
  const [datapoint, setDatapoint] = useState([]);
  var dataPoints = [];

  const dataP = async () => {
    await axios
      .get("https://canvasjs.com/data/gallery/react/nifty-stock-price.json")
      .then((res) => {
        setDatapoint(res.data);
      });
  };
  useEffect(() => {
    dataP();
  }, []);

  if (datapoint && datapoint.length > 0) {
    for (var i = 0; i < datapoint.length; i++) {
      dataPoints.push({
        x: new Date(datapoint[i].x),
        y: datapoint[i].y,
      });
    }
  }
  console.log("dataPoints", dataPoints);

  const optionsYMD = {
    theme: "light2",
    title: {
      text: "Comparison of Exchange Rates - 2017",
    },
    subtitles: [
      {
        text: "GBP & USD to INR",
      },
    ],
    axisY: {
      prefix: "₹",
    },
    toolTip: {
      shared: true,
    },
    data: [
      {
        type: "area",
        name: "GBP",
        showInLegend: true,
        xValueFormatString: "MMM YYYY",
        yValueFormatString: "₹#,##0.##",
        dataPoints: dataPoints,
      },
    ],
  };
  return (
    <div className="p-5">
      <div className="mt-[30px]">
        <h2 className="text-2xl font-bold text-blue-600">
          Chart area Year month day
        </h2>
        <CanvasJSChart options={optionsYMD} />
      </div>
    </div>
  );
};

export default BarChartArea;

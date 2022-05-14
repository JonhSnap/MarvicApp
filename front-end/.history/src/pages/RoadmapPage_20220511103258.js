import React from "react";
import Roadmap from "../components/roadmap/Roadmap";
import Sidebar from "../components/sidebar/Sidebar";

function RoadmapPage() {
  return (
    <div className="flex">
      <div className="basis-[20%]">
        <Sidebar></Sidebar>
      </div>
      <div className="basis-[80%]">
        <Roadmap></Roadmap>
      </div>
    </div>
  );
}

export default RoadmapPage;

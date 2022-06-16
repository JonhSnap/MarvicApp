import React, { useEffect } from "react";

const TestListPage = () => {
  useEffect(() => {
    document.title = "Test-result";
  }, []);
  return <div className="w-[1320px] mx-auto p-4">List-Page</div>;
};

export default TestListPage;

import React, { lazy, Suspense } from "react";
import { Routes, Route } from "react-router-dom";
import Main from "./components/layouts/Main";

const YourWorkPage = lazy(() => import("./pages/YourWorkPage"));
const ProjectsPage = lazy(() => import("./pages/ProjectsPage"));
const LoginPage = lazy(() => import("./pages/LoginPage"));
const RegisterPage = lazy(() => import("./pages/RegisterPage"));
const TutorialPage = lazy(() => import("./pages/TutorialPage"));
const TestPage = lazy(() => import("./pages/TestPage"));
const BoardPage = lazy(() => import("./pages/BoardPage"));
const BacklogPage = lazy(() => import("./pages/BacklogPage"));
const RoadmapPage = lazy(() => import("./pages/RoadmapPage"));

function App() {
  return (
    <Suspense fallback={<>Fall back component</>}>
      <Routes>
        <Route path="/" element={<Main></Main>}>
          <Route path="/" element={<YourWorkPage></YourWorkPage>}></Route>
          <Route path="/projects" element={<ProjectsPage></ProjectsPage>}></Route>
          <Route path="/projects/roadmap" element={<RoadmapPage></RoadmapPage>}></Route>
          <Route path="/projects/backlog/:key" element={<BacklogPage></BacklogPage>}></Route>
          <Route path="/projects/board/:key" element={<BoardPage></BoardPage>}></Route>
        </Route>
        <Route path="/login" element={<LoginPage></LoginPage>}></Route>
        <Route path="/register" element={<RegisterPage></RegisterPage>}></Route>
        <Route path="/tutorial" element={<TutorialPage></TutorialPage>}></Route>
        <Route path="/test" element={<TestPage></TestPage>}></Route>
      </Routes>
    </Suspense>
  );
}

export default App;

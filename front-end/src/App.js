import React, { lazy, Suspense } from "react";
import { Routes, Route } from "react-router-dom";
import Main from "./components/layouts/Main";
import { ToastContainer } from 'react-toastify'
import Loading from "./loading/Loading"

const YourWorkPage = lazy(() => import("./pages/YourWorkPage"));
const ProjectsPage = lazy(() => import("./pages/ProjectsPage"));
const LoginPage = lazy(() => import("./pages/LoginPage"));
const RegisterPage = lazy(() => import("./pages/RegisterPage"));
const TutorialPage = lazy(() => import("./pages/TutorialPage"));
const TutorialPage2 = lazy(() => import("./pages/Tutorial2"));
const TestPage = lazy(() => import("./pages/TestPage"));
const BoardPage = lazy(() => import("./pages/BoardPage"));
const BacklogPage = lazy(() => import("./pages/BacklogPage"));
const ArchiveIssuse = lazy(() => import("./pages/ArchiveIssuse"));
const RoadmapPage = lazy(() => import("./pages/RoadmapPage"));
const Comments = lazy(() => import("./components/comments/Comments"));
// const Loading = lazy(() => import("./loading/Loading"));

function App() {
  return (
      <Suspense fallback={<Loading></Loading>}>
      <ToastContainer
        position="top-right"
        autoClose={3000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss={false}
        draggable
        pauseOnHover={false}
      ></ToastContainer>
      <Routes>
        <Route path="/" element={<Main></Main>}>
          <Route path="/" element={<YourWorkPage></YourWorkPage>}></Route>
          <Route path="/projects" element={<ProjectsPage></ProjectsPage>}></Route>
          <Route path="/projects/roadmap" element={<RoadmapPage></RoadmapPage>}></Route>
          <Route path="/projects/backlog/:key" element={<BacklogPage></BacklogPage>}></Route>
          <Route path="/projects/archive/:key" element={<ArchiveIssuse></ArchiveIssuse>}></Route>
          <Route path="/projects/board/:key" element={<BoardPage></BoardPage>}></Route>
        </Route>
        <Route path="/login" element={<LoginPage></LoginPage>}></Route>
        <Route path="/register" element={<RegisterPage></RegisterPage>}></Route>
        <Route path="/tutorial" element={<TutorialPage></TutorialPage>}></Route>
        <Route path="/tutorial2" element={<TutorialPage2></TutorialPage2>}></Route>
        <Route path="/test" element={<TestPage></TestPage>}></Route>
        <Route
          path="/comment"
          element={
            <Comments commentURL="https://localhost:5001/hubs/marvic"></Comments>
          }
        ></Route>
      </Routes>
    </Suspense>
  );
}

export default App;

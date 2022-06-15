import React, { lazy, Suspense } from "react";
import { Routes, Route } from "react-router-dom";
import Main from "./components/layouts/Main";
import { ToastContainer } from "react-toastify";
import BoardPageEpic from "./pages/BoardPageEpic";

const YourWorkPage = lazy(() => import("./pages/YourWorkPage"));
const ArchivePage = lazy(() => import("./pages/ArchivePage"));
const ProfilePage = lazy(() => import("./pages/ProfilePage"));
const ProjectsPage = lazy(() => import("./pages/ProjectsPage"));
const LoginPage = lazy(() => import("./pages/LoginPage"));
const RegisterPage = lazy(() => import("./pages/RegisterPage"));
const TutorialPage = lazy(() => import("./pages/TutorialPage"));
const TestPage = lazy(() => import("./pages/TestPage"));
const BoardPage = lazy(() => import("./pages/BoardPage"));
const BacklogPage = lazy(() => import("./pages/BacklogPage"));
const RoadmapPage = lazy(() => import("./pages/RoadmapPage"));
const Comments = lazy(() => import("./components/comments/Comments"));
const DashboardPage = lazy(() => import("./pages/DashboardPage"));
const TestListPage = lazy(() => import("./pages/TestListPage"));
const TestResultPage = lazy(() => import("./pages/TestResultPage"));

function App() {
  return (
    <Suspense fallback={<>Fall back component</>}>
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
          <Route
            path="/projects"
            element={<ProjectsPage></ProjectsPage>}
          ></Route>
          <Route path="/profile" element={<ProfilePage></ProfilePage>}></Route>
          <Route
            path="/projects/dashboard/:key"
            element={<DashboardPage />}
          ></Route>
          <Route
            path="/projects/roadmap/:key"
            element={<RoadmapPage></RoadmapPage>}
          ></Route>
          <Route
            path="/projects/backlog/:key"
            element={<BacklogPage></BacklogPage>}
          ></Route>
          <Route
            path="/projects/board/:key"
            element={<BoardPage></BoardPage>}
          ></Route>
          <Route
            path="/projects/board/epic/:key"
            element={<BoardPageEpic></BoardPageEpic>}
          ></Route>
          <Route
            path="/projects/archive/:key"
            element={<ArchivePage></ArchivePage>}
          ></Route>
          <Route path="/test-results" element={<TestResultPage />}></Route>
          <Route
            path="/testlist"
            element={<TestListPage></TestListPage>}
          ></Route>
        </Route>
        <Route path="/login" element={<LoginPage></LoginPage>}></Route>
        <Route path="/register" element={<RegisterPage></RegisterPage>}></Route>
        <Route path="/tutorial" element={<TutorialPage></TutorialPage>}></Route>
        <Route path="/test/:id/:name" element={<TestPage></TestPage>}></Route>
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

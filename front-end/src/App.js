import React from 'react'
import TestPage from './pages/TestPage';
import TutorialPage from './pages/TutorialPage';

// const YourWord = lazy(() => import('./pages/YourWordPage'));
// const ProjectsPage = lazy(() => import('./pages/ProjectsPage'));


function App() {
  return (
    <>
    {/* <Suspense fallback={<>Component fallback</>}>
      <Routes>
        <Route element={<Main></Main>}>
          <Route path={'/'} element={<YourWord></YourWord>}></Route>
          <Route path={'/projects'} element={<ProjectsPage></ProjectsPage>}></Route>
        </Route>
      </Routes>
    </Suspense> */}
     <div className="App">
       <TestPage/>
      {/* <TutorialPage/> */}
     </div>
      {/* <Routes>
        <Route path="/" element={<Home></Home>}></Route>
        <Route path="/login" element={<Login></Login>}></Route>
        <Route path="/register" element={<Register></Register>}></Route>
      </Routes> */}
    </>



  );
}


export default App;

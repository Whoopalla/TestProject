import React from 'react';
import Home from './Components/Home';
import FirstTask from "./Components/FirstTask";
import SecondTask from "./Components/SecondTask";
import ThirdTask from "./Components/ThirdTask";


const AppRoutes = [
    {
      index: true,
      element: <Home />
    },
    {
      path: '/firstTask',
      element: <FirstTask />
    },
    {
      path: '/secondTask',
      element: <SecondTask />
    },
    {
      path: '/thirdTask',
      element: <ThirdTask />
    },
  ];
  
  export default AppRoutes;
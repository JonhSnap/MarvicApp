import React, { useState, useRef, useEffect } from "react";
import Tooltip from "../tooltip/Tooltip";

function Search({ setIsSearchFocus }) {
  const [isHover, setIsHover] = useState(false);
  const [coord, setCoord] = useState({});
  const searchRef = useRef();

  useEffect(() => {
    const searchRefCopy = searchRef;
    const handleSearchFocus = () => {
      setIsSearchFocus(true);
      setIsHover(false);
    };
    const handleSearchBlur = () => {
      setIsSearchFocus(false);
    };
    const handleMouseOver = (e) => {
      const bounding = e.target.getBoundingClientRect();
      setIsHover(true);
      setCoord(bounding);
    };
    const handleMouseLeave = () => {
      setCoord({});
      setIsHover(false);
    };
    searchRefCopy.current.addEventListener("focus", handleSearchFocus);
    searchRefCopy.current.addEventListener("blur", handleSearchBlur);
    searchRefCopy.current.addEventListener("mouseover", handleMouseOver);
    searchRefCopy.current.addEventListener("mouseleave", handleMouseLeave);
    //clean up
    // return () => {
    //   searchRefCopy.current.removeEventListener("focus", handleSearchFocus);
    //   searchRefCopy.current.removeEventListener("blur", handleSearchBlur);
    //   searchRefCopy.current.removedEventListener("mouseover", handleMouseOver);
    //   searchRefCopy.current.removedEventListener(
    //     "mouseleave",
    //     handleMouseLeave
    //   );
    // };


  return (
    <>
      {isHover && <Tooltip coord={coord}>Search issue</Tooltip>}
      <input ref={searchRef} type="text" placeholder="Search"></input>
    </>
  );
}
}

export default Search;

import React from "react";
import { Avatar, AvatarGroup } from "@mui/material";

import Tippy from "@tippyjs/react";
import { v4 } from "uuid";

function stringToColor(string) {
  let hash = 0;
  let i;

  /* eslint-disable no-bitwise */
  if (string) {
    for (i = 0; i < string.length; i += 1) {
      hash = string.charCodeAt(i) + ((hash << 5) - hash);
    }
  }

  let color = "#";

  for (i = 0; i < 3; i += 1) {
    const value = (hash >> (i * 8)) & 0xff;
    color += `00${value.toString(16)}`.slice(-2);
  }
  /* eslint-enable no-bitwise */

  return color;
}
function stringAvatar(name) {
  return {
    sx: {
      bgcolor: stringToColor(name),
    },
    children: `${name?.split(" ")[0][0]}${name?.split(" ")[1][0]}`,
  };
}

function ShowAllMemberIssue({ members }) {
  // handle change active

  return (
    <>
      <AvatarGroup onClick={handleClick} style={{ cursor: "pointer" }} max={3}>
        {members?.length > 0 &&
          members.map((item) => (
            <Tippy key={v4()} content={item.fullName}>
              {item.avatar_Path ? (
                <Avatar alt="Remy Sharp" src={item.avatar_Path} />
              ) : (
                <Avatar {...stringAvatar(item.fullName)} />
              )}
            </Tippy>
          ))}
      </AvatarGroup>
    </>
  );
}

export default ShowAllMemberIssue;

// <Avatar style={{ width: 25, height: 25, fontSize: 12 }} {...stringAvatar(item.fullName)} />

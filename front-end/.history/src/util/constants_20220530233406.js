import { v4 } from "uuid";
import StoryImage from "../images/type-issues/story.jpg";
import TaskImage from "../images/type-issues/task.jpg";
import BugImage from "../images/type-issues/bug.jpg";
// Base url
export const BASE_URL = "https://localhost:5001";
// inner height
export const documentHeight = window.innerHeight;
// key current project
export const KEY_CURRENT_PROJECT = "key_current_project";
// key timeline roadmap
export const KEY_FILTER_EPIC = "key_filter_epic";
// Levels
export const levels = [
  {
    id: v4(),
    value: 0,
    text: "Choose an access level",
  },
  {
    id: v4(),
    value: 1,
    text: "Public",
  },
  {
    id: v4(),
    value: 2,
    text: "Limited",
  },
  {
    id: v4(),
    value: 3,
    text: "Private",
  },
];
export const issueTypes = [
  {
    id: 2,
    value: 2,
    title: "story",
    thumbnail: StoryImage,
  },
  {
    id: 3,
    value: 3,
    title: "stask",
    thumbnail: TaskImage,
  },
  {
    id: 4,
    value: 4,
    title: "bug",
    thumbnail: BugImage,
  },
];

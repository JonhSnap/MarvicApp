import { useState } from "react";
import { createContext } from "react";


const replyCommentContext = createContext()
function UseReplyComment() {
    const [show, setShow] = useState(false);
    return [show, setShow]
}

function ReplyCommentProvider({children}) {
    const [show, setShow] = UseReplyComment()
}
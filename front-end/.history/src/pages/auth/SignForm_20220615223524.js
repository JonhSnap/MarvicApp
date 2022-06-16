import React from "react";
import SignFormContent from "./SignFormContent";
import SignFormHeader from "./SignFormHeader";

const SignForm = ({ Children }) => {
  return (
    <div className="relative inset-0 grid object-cover w-full grid-cols-2 mx-auto bg-cover cursor-pointer back sign-up">
      <SignFormHeader></SignFormHeader>
      <SignFormContent Children={Children}></SignFormContent>
    </div>
  );
};

export default SignForm;

import React from "react";
import SignFormContent from "./SignFormContent";
import SignFormHeader from "./SignFormHeader";

const SignForm = ({ Children }) => {
  return (
    <div className="w-full max-w-[1320px]  mx-auto sign-up  relative grid grid-cols-2 inset-0 object-cover cursor-pointer">
      <SignFormHeader></SignFormHeader>
      <SignFormContent Children={Children}></SignFormContent>
    </div>
  );
};

export default SignForm;

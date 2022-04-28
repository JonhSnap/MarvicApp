import React from "react";
import { useController } from "react-hook-form";

const InputHook = ({ control, ...props }) => {
  const { field } = useController({
    control,
    name: props.name,
    defaultValue: "",
  });
  //   console.log(field);
  return (
    <input
      type="text"
      className="p-3 transition-all bg-white border border-b-2 border-none rounded-lg outline-none focus:border-blue-500"
      {...field}
      {...props}
    />
  );
};

export default InputHook;

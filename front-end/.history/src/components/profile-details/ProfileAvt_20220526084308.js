import React from "react";

const ProfileAvt = () => {
  return (
    <form>
      <div className="mt-10 ml-5">
        <input
          type="file"
          name="image-upload"
          id="input-avt"
          accept="image/*"
          className="cursor-pointer "
          onChange={imageHandler}
        />
        <div className="inline-block p-2 mt-2 text-white transition-all cursor-pointer hover:bg-slate-400 hover: bg-slate-500 label-avt rounded-2xl">
          <label
            htmlFor="input-avt"
            className="flex items-center cursor-pointer image-upload"
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              className="w-6 h-6"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              strokeWidth="2"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                d="M4 16l4.586-4.586a2 2 0 012.828 0L16 16m-2-2l1.586-1.586a2 2 0 012.828 0L20 14m-6-6h.01M6 20h12a2 2 0 002-2V6a2 2 0 00-2-2H6a2 2 0 00-2 2v12a2 2 0 002 2z"
              />
            </svg>
            Thay đổi ảnh đại diện
          </label>
        </div>
      </div>

      <div className="">
        <button
          type="submit"
          className="px-2 py-3 mr-4 text-base text-white bg-blue-500 rounded-lg hover:bg-blue-600"
        >
          Post avt
        </button>
      </div>
    </form>
  );
};

export default ProfileAvt;

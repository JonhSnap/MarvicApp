import React from "react";

const TutorialDanhgia = () => {
  return (
    <div>
      <div className="">
        <h2 className="text-xl font-semibold">1. Điểm mạnh: </h2>
        <div className="ml-5">
          <p>
            • Cung cấp cho người dùng mới, 1 công cụ tiếp cận với mô hình quản
            lý Agile, gói gọn các chức năng quan trọng nhất trong 1 dự án áp
            dụng phương pháp Scrum.{" "}
          </p>
          <p>
            • Để giúp người mới dễ tiếp cận hơn, app giúp người dùng có thể sử
            dụng đồng thời nhiều account, phục vụ việc test 3 role của scrums từ
            đó hiểu được tổng quan việc quản lý 1 dự án theo Scrum.
          </p>
        </div>
      </div>
      <div className="mt-7">
        <h2 className="text-xl font-semibold">2. Điểm yếu: </h2>
        <div className="ml-5">
          <p>• Chưa thể tích hợp thêm các tiện ích từ bên thứ 3.</p>
          <p>
            • Chưa thể phát triển các chức năng với nghiệp vụ phức tạo để hỗ trợ
            doanh nghiệp lớn.
          </p>
          <p>
            • Chưa thể cung cấp các chức năng mở rộng và tùy biến cho người dùng
            nâng cao
          </p>
          <p>• Một số component chưa thể hoạt động realtime.</p>
          <p>• Chưa có các chức năng hỗ trợ người dùng liên tục.</p>
        </div>
      </div>
    </div>
  );
};

export default TutorialDanhgia;

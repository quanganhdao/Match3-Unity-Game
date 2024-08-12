+LevelCondition chỉ nên là 1 lớp xử lý thuần về logic chiến thắng của game, không nên tham chiếu đến UI và thực hiện các hành động liên quan đến UI như thay đổi nội dung của text trên UI 
⇒ Giải pháp: dùng Action hoặc event để phát ra các sự kiện, thành phần nào đăng ký sự kiện thì sẽ kích hoạt hành động dựa trên tham số truyền vào.

+Project fix cứng đường dẫn đến các prefab, mỗi Enum type tương ứng với 1 path đến prefab + hard code⇒ cồng kềnh, khó mở rộng
⇒ Giải pháp: dùng scriptable objects làm nơi chứa thông tin về skin, tạo 1 cấu trúc dữ liệu như dictionary hoặc list để set up từng enum tương ứng với từng scriptable object skin trên editor. Khi nào có thêm các set skin mới thì tạo scriptable object rồi kéo thả các skin vào danh sách của set skin mới trên editor
# Mind MVC 是一个轻量级的 C# 开发框架

Mind MVC 是为了在 Unity 做游戏开发而写的一款非常轻量级的 MVC 开发框架，代码量非常少，几分钟就可以熟悉，作为学习和开发都很合适。

## 什么是 MVC(Model-View-Controller)？

### Model

M(Model) 层，存储数据的地方，只提供2种接口，gets 和 sets 接口。

### View

V(View) 层，界面显示的地方，处理界面的显示逻辑并提供 update 接口（提供给 controller 调用）来更新界面。

### Controller

C(Controller) 层，处理消息并转发到其他层来处理具体业务，例如，需要存储和更新数据就转到 model 层处理，需要处理具体业务逻辑转到 service 层，需要显示界面就转到 view 层处理。

### Service

S(Service) 层，提供模块业务逻辑处理 、对外（其他模块）接口和与服务器端的交互。

### 消息定义

E(Event) 消息（事件）层，controller 与 controller 之间，model 与 controller，service 与 controller 之间的交互都是通过消息传递。

注意：controller 是不能直接获取它的对象，要与 controller 交互只能通过消息传递。

## 使用 

### 先继承这几层的基类来定义自己项目的基类

例如：

- BaseController
- BaseModel
- BaseService
- BaseView

具体模块继承以上的基类，未来需要通用的接口可以在基类中提供

### 注册模块

每一个模块的 Controller 需要进行注册才能接受消息

    Facade.GetInstance().RegisterObservers(new IController[] {
        new RoleController(),
    });

### Controller 消息订阅和处理

    public class RoleController : BaseController 
    {
        public RoleController()
        {
            Name = "RoleController";
        }

        // 消息订阅
        public override IHandler[] ListNotification()
        {
            return new IHandler[] {
                NewHandler(RoleEvent.EVENT_GAME_START, handleStartGame),
                NewHandler(RoleEvent.EVENT_ROLE_SHOW_INFO, handleShowInfo),
            };
        }

        // 消息处理
        public void handleStartGame(INotification notification)
        {
            Debug.Log("============== start game");
        }

        public void handleShowInfo(INotification notification)
        {
            Debug.Log("============== show role info");
        }
    }

### model service view 都是单例

可以通过提供以下方法来使用，例如角色模块的 model：

    public static RoleModel Self()
    {
        return Singleton<RoleModel>.GetInstance();
    }

使用时：

    RoleModel.Self();

### 消息定义到 model 同一文件

    public class RoleEvent
    {
        public static string EVENT_GAME_START = "EVENT_GAME_START";
        public static string EVENT_ROLE_SHOW_INFO = "EVENT_ROLE_SHOW_INFO";
    }

    public class RoleModel : BaseModel 
    {
        public RoleModel()
        {
        }

        // 使用单体模式
        public static RoleModel Self()
        {
            return Singleton<RoleModel>.GetInstance();
        }
    }

## 示例

- samples 目录下可以找到一些示例，会持续更新
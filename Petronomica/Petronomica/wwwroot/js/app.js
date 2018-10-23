function AppX()
{
    this._userinfo=null;
    this._strategy=null;
    this.screenMode=0;
    var currentstr;
    var self = this;
    window.addEventListener("load",Start);
    window.addEventListener("resize", Start);
   // var sw = new ServiceWorker();
    this.ShowUserInfo=function()
    {
        self._userinfo = new UserInfo(); 
        console.log(this._userinfo);
        console.log(window.document.head);
   
    }
    function SelectStrategy()
    {
       
       GetScenario();
  
       switch(self.screenMode)
       {
            case 0:self._strategy=new Context(new FHDStrategy());
            break;
            case 1:self._strategy=new Context(new Strategy1600());
            break;
            case 2:self._strategy=new Context(new Strategy1200());
            break;
            case 3:self._strategy=new Context(new Strategy1024());
            break;
            case 4:self._strategy=new Context(new StrategyMobile());
            break;
       }
    }
    function Start()
    {
        GetScenario();
        SelectStrategy();
        self._strategy.exec();
    }
    function GetScenario(){
    self._userinfo=new UserInfo();  
    if(self._userinfo.screenWidth<=1920 & self._userinfo.screenHeight <=1200)
    self.screenMode=0;
    if(self._userinfo.screenWidth<=1600 & self._userinfo.screenHeight <=1000)
    self.screenMode= 1;
    if(self._userinfo.screenWidth<=1200 & self._userinfo.screenHeight <=800)
    self.screenMode= 2;
    if(self._userinfo.screenWidth<=1024& self._userinfo.screenHeight <=768)
    self.screenMode= 3;
    if(self._userinfo.screenWidth<=768& self._userinfo.screenHeight <=420)
    self.screenMode= 4; 
    } 
}
function Context(strategy) {
    this.exec = function() {
        strategy.exec();
    };
}
function Strategy() {
    this.exec = function() {console.log('str')};
};
function FHDStrategy() {
    Strategy.call(this);
    this.exec = function () {
        console.log('FHD');
    };
};
function Strategy1600() {
    Strategy.call(this);
    this.exec = function () {
       
        console.log('1600');
    };
};
function Strategy1200() {
    Strategy.call(this);
    this.exec = function() {
        console.log('1200');
    };
}; 
function Strategy1024() {
    Strategy.call(this);
    this.exec = function () {
 
        console.log('1024');
    };
}; 
function StrategyMobile() {
    Strategy.call(this);
    this.exec = function () {
      
        console.log('Mobile');
    };
};



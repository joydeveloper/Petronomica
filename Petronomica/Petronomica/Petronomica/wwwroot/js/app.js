function AppX() {
    this._userinfo = null;
    this._strategy = null;
    this.screenMode = 0;
    var currentstr;
    var self = this;
    window.addEventListener("load", Start);
    window.addEventListener("resize", Start);
    // var sw = new ServiceWorker();
    this.ShowUserInfo = function () {
        self._userinfo = new UserInfo();
        console.log(this._userinfo);
        console.log(window.document.head);

    }
    function SelectStrategy() {
        GetScenario();
        switch (self.screenMode) {
            case 0: self._strategy = new Context(new FHDStrategy());
                break;
            case 1: self._strategy = new Context(new MidStrategy());
                break;
            case 2: self._strategy = new Context(new MidStrategy());
                break;
            case 3: self._strategy = new Context(new LowStrategy());
                break;
            case 4: self._strategy = new Context(new TabletStrategy());
                break;
            case 5: self._strategy = new Context(new MobileStrategy());
                break;
        }
    }
    function Start() {
        GetScenario();
        SelectStrategy();
        self._strategy.exec();
    }
    function GetScenario() {
        self._userinfo = new UserInfo();
        if (self._userinfo.screenWidth <= 1920 & self._userinfo.screenHeight <= 1200)
            self.screenMode = 0;
        if (self._userinfo.screenWidth <= 1600 & self._userinfo.screenHeight <= 1000)
            self.screenMode = 1;
        if (self._userinfo.screenWidth <= 1200 & self._userinfo.screenHeight <= 800)
            self.screenMode = 2;
        if (self._userinfo.screenWidth <= 1024 & self._userinfo.screenHeight <= 768)
            self.screenMode = 3;
        if (self._userinfo.screenWidth <= 1024 & self._userinfo.screenHeight <= 768 & self._userinfo.isMobile)
            self.screenMode = 4;
        if (self._userinfo.screenWidth <= 768 & self._userinfo.screenHeight <= 420)
            self.screenMode = 5;
    }
}
function Context(strategy) {
    this.exec = function () {
        strategy.exec();
    };
}
function Strategy() {
    this.exec = function () { console.log('str') }
};
function FHDStrategy() {
    Strategy.call(this);
    this.exec = function () {
        console.log('FHD');
    };
};
function MidStrategy() {
    Strategy.call(this);
    this.exec = function () {

        console.log('Mid');
    };
};

function LowStrategy() {
    Strategy.call(this);
    this.exec = function () {

        console.log('Low');
    };
};
function TabletStrategy() {
    Strategy.call(this);
    this.exec = function () {

        console.log('Tablet');
    };
};
function MobileStrategy() {
    Strategy.call(this);
    this.exec = function () {

        console.log('Mobile');
    };
};




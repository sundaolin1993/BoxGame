var line = '' // 记录玩家选择的棋子所在行的信息
var sum = 1 // 记录玩家点击次数，默认奇数次数是甲方，偶数次数是乙方
// 创建棋子函数
const createBox = function (e, number, dataName) {
  e.innerHTML = ''
  for (let i = 0; i < number; i++) {
    //创建游戏棋子
    const box = document.createElement('span')
    box.className = 'toothpick'
    box.setAttribute('data-flag', dataName)
    //添加鼠标移入的事件
    box.onmouseover = function () {
      this.classList.add("backgroundblue")
    }
    //添加鼠标离开的事件
    box.onmouseout = function () {
      this.classList.remove('backgroundblue')
    }
    //添加棋子点击事件，改变颜色，表示选中
    box.onclick = function () {
      //清空提示消息框
      document.getElementById('tips').innerText = ''
      const dataFlag = this.getAttribute('data-flag')
      if (!line) line = dataFlag
      if (line !== dataFlag) {
        //选中不同行
        document.getElementById('tips').innerText = '请选择同一行内的棋子'
      } else {
        //选中相同行
        this.classList.contains('selected') ? this.classList.remove('selected') : this.classList.add('selected')
        //取消选中时，判断当前行还有没有被选中，如果没有，就把line清空，方便选择其他行
        const nodes = [].slice.call(this.parentNode.children)
        if (!nodes.some(e => e.classList.contains('selected'))) line = ''
      }
    }
    e.appendChild(box)
  }
}
// 走棋函数
const play = function () {
  //清空提示消息框
  document.getElementById('tips').innerText = ''
  if (!line) return document.getElementById('tips').innerText = '请选棋子'
  //移除选中的棋子
  document.querySelectorAll('.selected').forEach(e => e.parentNode.removeChild(e))
  line = ''
  sum++
  // 根据点击次数判断是甲方还是乙方走棋
  const play = sum % 2 !== 0 ? '甲' : '乙'
  document.getElementById('whichone').innerText = play
  //判断桌上剩余棋子数量
  const boxs = document.querySelectorAll('.toothpick').length
  if (boxs < 2) {
    //禁用走棋按钮
    document.getElementById('btnrun').disabled = true
    // 根据所剩棋子数量判断输赢
    const msg = boxs === 1 ? play + '方输' : '甲方输'
    document.getElementById('currentrun').innerHTML = msg
    document.getElementById('tips').innerText = msg
  }
}
// 复原函数
const rest = function () {
  //复原提示标签
  document.getElementById('currentrun').innerHTML = '当前应该<i id="whichone">甲</i> 方走棋'
  //启用走棋按钮
  document.getElementById('btnrun').disabled = false
  //清空提示消息框
  document.getElementById('tips').innerText = ''

  //创建三行相同棋子，每行标记不同，分别使用one，two，three 类名标识
  createBox(document.getElementById('one'), 3, 'one')
  createBox(document.getElementById('two'), 5, 'two')
  createBox(document.getElementById('three'), 7, 'three')

  //注册走棋按钮的点击事件
  document.getElementById('btnrun').onclick = play
}

// 初始化页面
rest()
// 点击复原按钮
document.getElementById('recover').onclick = rest
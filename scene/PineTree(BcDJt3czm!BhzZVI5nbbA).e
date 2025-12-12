13
3212635537409
404836870638822 1761863283060356800
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -2.3242034912109375,
    "Y": 9.7067880630493164
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404833652599364:1761863282310550800",
  "next_sibling": "404841735100407:1761863284193781600",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404836870868227:1761863283060409600",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404836870995335:1761863283060439200",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404836870868227:1761863283060409600",
    "DefaultRenderer": "404836871057986:1761863283060453800",
    "DepletedRenderer": "404836871042592:1761863283060450200"
  }
},
{
  "cid": 5,
  "aoid": "404836871006730:1761863283060441900",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}

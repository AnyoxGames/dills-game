13
4007204487169
404959689068001 1761863311677178100
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -8.6524543762207031,
    "Y": -11.5869369506835938
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404958258315413:1761863311343811400",
  "next_sibling": "404961620136296:1761863312127119000",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404959689391490:1761863311677252600",
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
  "aoid": "404959689542592:1761863311677287900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404959689391490:1761863311677252600",
    "DefaultRenderer": "404959689598363:1761863311677300800",
    "DepletedRenderer": "404959689579013:1761863311677296300"
  }
},
{
  "cid": 5,
  "aoid": "404959689556868:1761863311677291100",
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

13
4264902524929
404989374287415 1761863318593864900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -5.7021183967590332,
    "Y": -12.0145215988159180
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404983293587500:1761863317177055600",
  "next_sibling": "404991949140405:1761863319193808400",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404989374690196:1761863318593958000",
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
  "aoid": "404989374848651:1761863318593994900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404989374690196:1761863318593958000",
    "DefaultRenderer": "404989374933189:1761863318594014600",
    "DepletedRenderer": "404989374905669:1761863318594008200"
  }
},
{
  "cid": 5,
  "aoid": "404989374872645:1761863318594000500",
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
